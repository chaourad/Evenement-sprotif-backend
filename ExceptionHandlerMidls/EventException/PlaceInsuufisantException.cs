namespace evenement.ExceptionHandlerMidls.EventException
{
    public class PlaceInsuufisantException : CustomException.CustomException
    {
        public PlaceInsuufisantException(string message, int status) : base(message, status)
        {
        }
    }
}