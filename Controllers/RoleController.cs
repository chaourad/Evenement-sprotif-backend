using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using evenement.Dto;
using evenement.Modals;
using evenement.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace evenement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepoitory _rolerepository;
        public RoleController(IRoleRepoitory role){
            _rolerepository = role;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Role>> GetAllRole() =>Ok( _rolerepository.GetAll());
       
       [HttpPost]
       public ActionResult<Role> Create(CreateRoleDto role){
        return _rolerepository.CreatRole(role);
       }
    }
}