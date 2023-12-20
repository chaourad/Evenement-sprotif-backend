
using System.Net;
using AutoMapper;
using evenement.Data;
using evenement.Dto.Message;
using evenement.ExceptionHandlerMidls.EventException;
using evenement.ExceptionHandlerMidls.UserException;
using evenement.Modals;
using evenement.Repository.IRepository;
using evenement.Utils;

namespace evenement.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
       public MessageRepository(AppDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       public Message EnvoieMessage(CreateMessageDto create)
        {

          /**   User? user = _context.Users.Where(u => u.Id == create.UserId).FirstOrDefault();
            if(user is null){
                throw new UserNotFoundException(ErrorMessages.UserNotFoundException, (int)HttpStatusCode.NotFound);
            }
             var newMessage = _mapper.Map<CreateMessageDto,Message>(create);
            if(newMessage is null){
                throw new EventNotFoundException(ErrorMessages.EventNotFoundException, (int)HttpStatusCode.NotFound);

            }
            _context.Messages.Add(newMessage);
            _context.SaveChanges();*/
            return null;
        }


    }
}