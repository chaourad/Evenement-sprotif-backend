
using AutoMapper;
using evenement.Data;
using evenement.Dto;
using evenement.Modals;
using evenement.Repository.IRepository;

namespace evenement.Repository
{
    public class RoleRepository : IRoleRepoitory
    {
         private readonly AppDbContext _context;
        private readonly IMapper _mapper;
       public RoleRepository(AppDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Role CreatRole(CreateRoleDto role)
        {
            var newRole = _mapper.Map<CreateRoleDto, Role>(role);
            _context.Roles.Add(newRole);
            _context.SaveChanges();
            return newRole;
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles;
        }

        public Role GetRoleById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}