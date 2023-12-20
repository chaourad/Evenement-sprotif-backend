using AutoMapper;
using evenement.Data;
using evenement.Dto.Type;
using evenement.Modals;
using evenement.Repository.IRepository;

namespace evenement.Repository
{
    public class TypeRepository : ITypeRepository
    {
         private readonly AppDbContext _context;
        private readonly IMapper _mapper;
       public TypeRepository(AppDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public TypeEvn Create(CreateTypeDto createType)
        {
            var newType = _mapper.Map<CreateTypeDto , TypeEvn>(createType);
            _context.Types.Add(newType);
            _context.SaveChanges();
            return newType;
        }

        public IEnumerable<TypeEvn> GetAll()
        {
            return _context.Types;
        }
    }
}