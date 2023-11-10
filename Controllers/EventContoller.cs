using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace evenement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EventContoller : ControllerBase
    {
        [HttpGet("Event")]
        public string[] GetUserName()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string[] roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).First().Value.Trim().Split(" ");
            return roles;
        }
    }
}