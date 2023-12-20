using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using evenement.Dto.Type;
using evenement.Modals;
using evenement.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace evenement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeController : ControllerBase
    {
         private readonly ITypeRepository _typerepository;
        public TypeController(ITypeRepository typerepository){
            _typerepository = typerepository;
        }
        [HttpPost("Save")]
        public ActionResult<TypeEvn> Create(CreateTypeDto create){
            return  Ok(_typerepository.Create(create));
        }
        [HttpGet("AllType")]
        public ActionResult<IEnumerable<TypeEvn>> GetallType(){
            return Ok(_typerepository.GetAll());
        }
    }
}