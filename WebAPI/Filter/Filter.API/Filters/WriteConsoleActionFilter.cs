using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filter.API.Filters
{
    public class WriteConsoleActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine($"Filter. BEFORE");

            await next();

            Console.WriteLine($"Filter. AFTER");
        }
    }
}