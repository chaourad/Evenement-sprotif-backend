using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evenement.ExceptionHandlerMidls.EventException
{
    public class EventNotFoundException : CustomException.CustomException
    {
        public EventNotFoundException(string message, int status) : base(message, status)
        {
        }
    }
}