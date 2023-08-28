using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace DealershipManager.Middleware
{
     public class ExceptionHandlingMiddleware : IMiddleware
     {
          public async Task InvokeAsync(HttpContext context, RequestDelegate next)
          {
               try
               {
                    await next(context);
               }
               catch (Exception ex)
               {
                    await HandleException(context, ex);
               }
          }
          private static async Task HandleException(HttpContext context, Exception ex)
          {
               context.Response.StatusCode = 500;
               context.Response.ContentType = "application/json";

               var error = new
               {
                    Message = "An error occurred while processing your request.",
                    ExceptionMessage = ex.Message,
               };

               var jsonResponse = JsonConvert.SerializeObject(error);
               await context.Response.WriteAsync(jsonResponse);
          }
     }
}
