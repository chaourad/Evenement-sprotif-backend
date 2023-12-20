using evenement.Dto.Type;
using evenement.Modals;

namespace evenement.Repository.IRepository
{
    public interface ITypeRepository
    {
        TypeEvn Create(CreateTypeDto createType);
        IEnumerable<TypeEvn> GetAll();
    }
}