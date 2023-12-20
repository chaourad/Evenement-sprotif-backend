
using evenement.Dto.Evenement;
using evenement.Dto.Message;
using evenement.Modals;

namespace evenement.Repository.IRepository
{
    public interface IEvenementRepository
    {
        IEnumerable<Evenement> GetEvenements();
        Evenement Update(Guid Id,UpdateEvenement update);
        Evenement Create(CreateEvemenet create);
        Evenement Inscription(IscriptionAUnEvenemntDto iscription);
        string Dalete(Guid Id);
        Evenement GetById(Guid Id);
        Evenement ValidatePArticipantofEvent(IscriptionAUnEvenemntDto iscription);
        IEnumerable<Evenement> GetAllEventByOrganisateur(Guid id);
        string EnvoieMessage(Guid idEvn,CreateMessageDto createmsg);

    }
}