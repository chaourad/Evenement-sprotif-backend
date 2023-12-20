using AutoMapper;
using evenement.Data;
using evenement.Modals;
using evenement.Repository.IRepository;

namespace evenement.Repository
{
    public class UserRepository : IUserRepository
    {
          private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<Message> GetAllMessages(Guid id)
        {
            IEnumerable<Message> msg = _context.Messages.Where(u => u.UserId == id).ToList();

            return msg;
        }
    }
}