using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace _04_UseMethod
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                Debug.WriteLine("Use1 before next");

                await next(); // вызов следующего middleware в цепочке

                Debug.WriteLine("Use1 after next");
            });

            app.Use(async (context, next) =>
            {
                Debug.WriteLine("Use2 before next");

                await next(); // вызов следующего middleware в цепочке

                Debug.WriteLine("Use2 after next");
            });

            app.Use(async (context, next) =>
            {
                Debug.WriteLine("Use3"); // В данном middleware не вызывается метод next. Цепочка на этом middleware заканчивается и контекст направляется в обратную сторону
                //await next();
            });
        }
    }
}
