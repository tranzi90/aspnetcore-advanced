using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace _06_UseMethod
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.Use(async (context, next) =>
            {
                // установка функции, которая должна выполниться сразу перед отправкой заголовков клиенту
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers.Add("CUSTOM-HEADER", "CUSTOM VALUE");
                    // функция, которая передается в OnStrating должна возвращать Task
                    return Task.CompletedTask;
                });

                await next();
            });

            app.Run(async context => await context.Response.WriteAsync("06_UseMethod"));
        }
    }
}
