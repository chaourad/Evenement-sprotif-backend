using System.Security.Claims;
using evenement.Dto.Evenement;
using evenement.Dto.Message;
using evenement.Modals;
using evenement.Repository;
using evenement.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace evenement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EventContoller : ControllerBase
    {
        private readonly IEvenementRepository _eventRepository;
        public EventContoller(IEvenementRepository eventRepository){
                _eventRepository = eventRepository;
        }
        [HttpGet("Event")]
        public string[] GetUserName()
        {  
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string[] roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).First().Value.Trim().Split(" ");
            return roles;
        }
        [HttpPost ("Save")]
        public  ActionResult<Evenement> CreateEvent(CreateEvemenet create){
            return Ok(_eventRepository.Create(create));
        }

        [HttpGet("All")]
        public ActionResult<IEnumerable<Evenement>> GetAll(){
            return Ok( _eventRepository.GetEvenements());
        }
        [HttpPost("InscriptionEvent")]
        public ActionResult<Evenement> InscriptionEvent(IscriptionAUnEvenemntDto iscription){
            return Ok(_eventRepository.Inscription(iscription));
        }
        [HttpPut("ValidatePArticipant")]
        public ActionResult<Evenement> Validate(IscriptionAUnEvenemntDto iscription){
            return Ok(_eventRepository.ValidatePArticipantofEvent(iscription));
        }
        [HttpDelete("Delete")]
        public ActionResult<string> Delete(Guid Id){
            return Ok(_eventRepository.Dalete(Id));
        }
        [HttpGet("Id:Guid")]
        public ActionResult<Evenement> GetById(Guid Id){
            return Ok(_eventRepository.GetById(Id));
        }
        [HttpPost("Envoie/id:Guid")]
        public ActionResult<string> Envoie(Guid id,CreateMessageDto create){
            return Ok(_eventRepository.EnvoieMessage(id,create));
        }
        [HttpPut("Update/id:Guid")]
        public ActionResult<Evenement> UpdateEvnt(Guid Id , UpdateEvenement up){
            return Ok(_eventRepository.Update(Id ,up));
            
        }
    }
}