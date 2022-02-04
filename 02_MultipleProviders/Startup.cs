using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _02_MultipleProviders
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                string property1 = Configuration["Property1"];
                string property2 = Configuration["Property2"];
                string url = Configuration["apiUrl"];
                // для того чтобы установить переменные окружения для Windows Control Panel > System > Advanced system settings 
                // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-2.1
                // Перезапустите студию после установки переменных окружения
                string envVal = Configuration["TESTVAR"]; 
                //string envVal = Configuration["ASPNETCORE_ENVIRONMENT"]; // данные настройки находятся Properties/launchSettings.json файле

                await context.Response.WriteAsync($"Property 1: {property1}, Property 2: {property2}, Url: {url}, Environment: {envVal}");
            });
        }
    }
}
