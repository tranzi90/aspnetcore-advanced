using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace _05_UseMethod
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
                context.Response.Headers.Add("CUSTOM-HEADER", "CUSTOM VALUE");
                await next();
                // Выполнять изменение ответа (Response) запрещено после вызова метода next
                //context.Response.Headers.Add("CUSTOM-HEADER", "CuSTOM VALUE");
            });

            app.Run(async context => await context.Response.WriteAsync("05_UseMethod"));
        }
    }
}


