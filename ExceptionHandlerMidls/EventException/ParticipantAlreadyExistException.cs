
namespace evenement.ExceptionHandlerMidls.EventException
{
    public class ParticipantAlreadyExistException : CustomException.CustomException
    {
        public ParticipantAlreadyExistException(string message, int status) : base(message, status)
        {
        }
    }
}