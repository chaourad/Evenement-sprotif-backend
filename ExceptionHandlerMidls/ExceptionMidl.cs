using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using evenement.ExceptionHandlerMidls.UserException;

namespace evenement.ExceptionHandlerMidls
{
    public class ExceptionMidl: IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
           
            catch(UserNotFoundException e){
                await WriteErrorMessage(e.Message,e.Status,context);
            }
            catch(UserAlreadyExistException e){
                await WriteErrorMessage(e.Message ,e.Status,context);
            }
            catch(PasswordNotFoundExcpetion e){
                await WriteErrorMessage(e.Message ,e.Status,context);

            }
            catch (Exception e)
            {
               await WriteErrorMessage(e.Message,500,context);
            }
        }

        private async Task WriteErrorMessage(string message, int status, HttpContext context)
        {
            context.Response.StatusCode = status;
            await context.Response.WriteAsJsonAsync(message);
        }
    }
}





   