using Microsoft.AspNetCore.Http;
using MvcStartApp.Models.Db;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MvcStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogsRepository _logsRepository;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, ILogsRepository logsRepository)
        {
            _next = next;
            _logsRepository = logsRepository;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            //LogConsole(context);
            await LogDb(context);

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }

        private async Task LogDb(HttpContext context)
        {
            await _logsRepository.AddRequest(context.Request.Host.Value);
        }

        private void LogConsole(HttpContext context)
        {
            // Для логирования данных о запросе используем свойста объекта HttpContext
            Debug.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
        }
    }
}
