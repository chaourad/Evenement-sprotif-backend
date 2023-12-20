using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evenement.ExceptionHandlerMidls.TypeException
{
    public class TypeNotFoundException : CustomException.CustomException
    {
        public TypeNotFoundException(string message, int status) : base(message, status)
        {
        }
    }
}