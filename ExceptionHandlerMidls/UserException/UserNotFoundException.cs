using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evenement.ExceptionHandlerMidls.UserException
{
    public class UserNotFoundException: CustomException.CustomException
    {
        public UserNotFoundException(string message, int status) : base(message, status)
        {
        }
    }
}