
using evenement.Dto;
using evenement.Modals;

namespace evenement.Repository.IRepository
{
    public interface IRoleRepoitory
    {
      IEnumerable<Role> GetAll();
        Role CreatRole(CreateRoleDto role);
        Role GetRoleById(Guid id);   
    }
}