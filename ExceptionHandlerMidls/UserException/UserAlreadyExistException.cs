using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evenement.ExceptionHandlerMidls.UserException
{
    public class UserAlreadyExistException: CustomException.CustomException
    {
        public UserAlreadyExistException(string message, int status) : base(message, status)
        {
        }
    }
}