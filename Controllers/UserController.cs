using System.Net;
using evenement.Data;
using evenement.Dto.User;
using evenement.ExceptionHandlerMidls.UserException;
using evenement.Modals;
using evenement.Repository.IRepository;
using evenement.Utils;
using Microsoft.AspNetCore.Mvc;

namespace evenement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        IUserRepository _userRepository;
        AppDbContext _context;
        public UserController(IUserRepository userRepository , AppDbContext context){
            _userRepository=userRepository;
            _context = context;
        }
        [HttpGet("Message/id:Guid")]
        public ActionResult<IEnumerable<Message>> GetAllMessage(Guid id){
            return Ok(_userRepository.GetAllMessages(id));
        }
        [HttpPut("Update")]
        public ActionResult<User> Update(Guid id , UpdateUserDto update ){
            User user = _context.Users.Where(u => u.Id == id).First();
            if (user != null){
                throw new UserNotFoundException(ErrorMessages.UserNotFoundException, (int)HttpStatusCode.NotFound);
            }
            user.Username = update.Username;
            user.Email = update.Email;
            user.Name = update.Name;
            _context.Users.Update(user);
            _context.SaveChanges();
            return Ok(user);

        }
    }
}