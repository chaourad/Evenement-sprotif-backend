using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evenement.ExceptionHandlerMidls.UserException
{
    public class PasswordNotFoundExcpetion: CustomException.CustomException
    {
        public PasswordNotFoundExcpetion(string message, int status) : base(message, status)
        {
        }
    }
}