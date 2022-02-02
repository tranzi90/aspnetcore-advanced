using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace HttpContextItems
{
    public class MyCustomMiddleware
    {
        private readonly RequestDelegate _next;
        public static readonly object MyCustomMiddlewareKey = new object();

        public MyCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Такой подход гарантирует отсутствие конфликтов из-за имен ключей в коллекции Items
            // в случае если middleware создается для использования в разных приложениях.
            context.Items[MyCustomMiddlewareKey] = "Hello world";

            await _next(context);
        }
    }

    public static class MyCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
