using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evenement.Utils
{
    public class ErrorMessages
    {
        public static string UserNotFoundException => " User Not Found";
        public static string PasswordNotFoundExcpetion => " Password  or Email is not correct please try again later!";
        public static string UserAlreadyExistException => " Username is already exist  please try again later!";
        public static string EventNotFoundException => " Evenment Not Found";
        public static string TypeNotFoundException => " Type Not Found";
        public static string PlaceInsuufisantException => " Place Insuffisant for this Evenment";
        public static string ParticipantAlreadyExistException => " Username is already exist !";


   
    }
}