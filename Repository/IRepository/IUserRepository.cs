using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using evenement.Modals;

namespace evenement.Repository.IRepository
{
    public interface IUserRepository
    {
        IEnumerable<Message> GetAllMessages(Guid id);
    }
}