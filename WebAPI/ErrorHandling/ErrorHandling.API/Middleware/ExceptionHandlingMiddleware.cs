using System;
using System.Net;
using System.Threading.Tasks;
using ErrorHandling.API.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ErrorHandling.API.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong.", ex);

                int statusCode = (int)HttpStatusCode.InternalServerError;
                string message = "An unhandled exception occured";

                if (ex is CustomExceptionBase customException)
                {
                    statusCode = customException.StatusCode;
                    message = customException.Message;
                }

                await context.Response.WriteAsJsonAsync(new { message, statusCode });
            }
        }
    }
}