
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using evenement.Data;
using evenement.Dto.User;
using evenement.ExceptionHandlerMidls.UserException;
using evenement.Modals;
using evenement.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace evenement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        public readonly AppDbContext _context;
          public readonly IConfiguration _configuration;
        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration= configuration;
        }
          [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(RegisterDto request)
        {
            List<Role> roles = _context.Roles.Where(role => role.Name=="organisateur"|| role.Name=="utilisateur").ToList();
            if (request is null)
                throw new UserNotFoundException(ErrorMessages.UserNotFoundException, (int)HttpStatusCode.NotFound);

            //if username already exist  
            User? u = _context.Users.Where(u => u.Email == request.Email ||  u.Username == request.Username).FirstOrDefault();
            if (u != null)
                throw new UserAlreadyExistException(ErrorMessages.UserAlreadyExistException, (int)HttpStatusCode.BadRequest);
            CreatePAsswordHAsh(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User userr = new()
            {
                Name = request.Name,
                Username = request.Username,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = roles
            };
            _context.Users.Add(userr);
            await _context.SaveChangesAsync();
            return Ok(userr);
        }
         [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserDto userDto)
        {
            var user =await _context.Users.Where(u => u.Email == userDto.Email).Include(r=>r.Role).FirstOrDefaultAsync();

            if (user == null)
                throw new UserNotFoundException(ErrorMessages.UserNotFoundException, (int)HttpStatusCode.NotFound);

            if (!VerifyPasswordHAsh(userDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new PasswordNotFoundExcpetion(ErrorMessages.PasswordNotFoundExcpetion, (int)HttpStatusCode.NotFound);
            }
            string token = CreateToken(user);
            return Ok(token);
        }

          private string CreateToken(User user)
        {
            string userRoles="";
            user.Role.ForEach((role)=>{
                userRoles +=role.Name+" ";
            });
            userRoles.TrimEnd();
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role,userRoles )

            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        private bool VerifyPasswordHAsh(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        private void CreatePAsswordHAsh(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}