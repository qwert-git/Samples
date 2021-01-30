using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Filter.API.Middleware
{
    public class ConsoleWriteMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine($"Middleware. BEFORE");

            await next(context);

            Console.WriteLine($"Middleware. AFTER");
        }
    }
}