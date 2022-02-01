using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace _07_CustomMiddlewareComponent
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<MyMiddleware>(); // использование пользовательского компонента Middleware

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("07_CustomMiddlewareComponent");
            });
        }
    }
}
