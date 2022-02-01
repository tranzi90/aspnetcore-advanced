using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace UsingRunMethod
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // С помощью метода Run можно создать простой middleware, который всегда возвращает ответ.
            // context - HttpContext - объект, который содержит данные запроса и будущего ответа.
            // Этот middleware не передает данные следующим компонентам в pipeline, его нужно устанавливать последним в pipeline
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("test string");
            });
            app.Run(async (context) =>
            {
                string agentName = context.Request.Headers["User-Agent"];
                await context.Response.WriteAsync("Request from " + agentName);
            });

            // этот middleware не будет запущен


        }
    }
}


