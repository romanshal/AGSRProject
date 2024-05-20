using AGSRProject.Common.Models.Responses;
using System.Net;

namespace AGSRProject.Middlewares
{
    public class ExceptionWrappingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public ExceptionWrappingMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await this._requestDelegate(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExeptionAsync(httpContext, ex);
            }
        }

        private Task HandleExeptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.StatusCode = (int)GetErrorCode(ex);
            var responseDate = GetResponseDate(ex);

            return httpContext.Response.WriteAsync(responseDate.ToString());
        }

        private static HttpStatusCode GetErrorCode(Exception ex)
        {
            switch (ex)
            {
                case ArgumentNullException error:
                    return HttpStatusCode.BadRequest;
                case NotImplementedException error:
                    return HttpStatusCode.NotImplemented;
                default:
                    return HttpStatusCode.InternalServerError;
            }
        }

        private static Response GetResponseDate(Exception ex)
        {
            switch (ex)
            {
                case ArgumentNullException error:
                    return new Response ("ArgumentNullException", true);
                case NotImplementedException error:
                    return new Response("NotImplementedException", true);
                default:
                    return new Response("InternalServerError", true);
            }
        }
    }

    public static class ExeptionWrappingMiddlewareExtention
    {
        public static IApplicationBuilder UseExeptionWrappingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionWrappingMiddleware>();
        }
    }
}
