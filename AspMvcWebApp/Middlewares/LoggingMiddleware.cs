using Microsoft.AspNetCore.Http;
using MvcStartApp.Repositories;
using System;
using System.Threading.Tasks;

namespace CoreStartApp
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogsRepository _repo;

        public LoggingMiddleware(RequestDelegate next, ILogsRepository repo)
        {
            _next = next;
            _repo = repo;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            LogConsole(context);
            await LogDb(context);
            await _next.Invoke(context);
        }

        private void LogConsole(HttpContext context)
        {
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
        }

        private async Task LogDb(HttpContext context)
        {
            await _repo.AddRequest($"http://{context.Request.Host.Value + context.Request.Path}");
        }
    }
}
