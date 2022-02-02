using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HttpContextItems
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                // Коллекция Items применяется для сохранения информации при обработке одного запроса
                // Данные, которые находятся в коллекции могут использоваться разными компонентами, которые участвуют в обработке запроса
                context.Items["myKey"] = 123;

                await next();
            });

            app.UseMyCustomMiddleware();

            app.Run(async (context) =>
            {
                var value = context.Items["myKey"];
                var message = context.Items[MyCustomMiddleware.MyCustomMiddlewareKey];

                await context.Response.WriteAsync($"{message}! {value}.");
            });
        }
    }
}

