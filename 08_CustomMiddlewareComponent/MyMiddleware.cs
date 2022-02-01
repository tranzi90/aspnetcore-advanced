using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace _08_CustomMiddlewareComponent
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.OnStarting(() =>
            {
                context.Response.Headers.Add("CUSTOM-HEADER", "CUSTOM VALUE");
                return Task.CompletedTask;
            });

            await _next.Invoke(context);
        }
    }

    public static class MiddlewareExtensions
    {
        // Расширяющий метод для подключение middleware к pipline
        public static IApplicationBuilder UseMy(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyMiddleware>();
        }
    }
}
