
using evenement.Dto.Message;
using evenement.Modals;

namespace evenement.Repository.IRepository
{
    public interface IMessageRepository
    {
        Message EnvoieMessage(CreateMessageDto create);
    }
}