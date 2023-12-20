using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using evenement.Dto.Message;
using evenement.Modals;
using evenement.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace evenement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        IMessageRepository _messageRepository;
        public MessageController(IMessageRepository messageRepository){
                _messageRepository = messageRepository;
        }
        [HttpPost("Envoie")]
        public ActionResult<Message> Envoie(CreateMessageDto create){
            return Ok(_messageRepository.EnvoieMessage(create));
        }
    }
}