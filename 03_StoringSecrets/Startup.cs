using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _03_StoringSecrets
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
                // Во время разработки будут использоваться секреты, находящиеся за пределами исходного кода в файле
                // %APPDATA%\Microsoft\UserSecrets\<user_secrets_id>\secrets.json
                // В Production коде будут использоваться секреты из переменных окружения
                string login = Configuration["login"];
                string password = Configuration["password"];

                await context.Response.WriteAsync($"Login: {login}, Password: {password}");
            });
        }
    }
}

