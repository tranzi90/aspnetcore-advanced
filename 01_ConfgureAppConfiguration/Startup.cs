using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _01_ConfgureAppConfiguration
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
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
                // чтение одного значения из файла конфигурации
                string message = Configuration["MainMessage"];

                // чтение настроек, находящихся в секциях файла конфигурации (во вложенных объектах в JSON)
                string x = Configuration["Point:XCoord"];

                // чтение секции для последующего доступа к значениям
                IConfigurationSection pointSection = Configuration.GetSection("Point");
                string y = pointSection["YCoord"];
                string z = pointSection["ZCoord"];

                await context.Response.WriteAsync($"{message} ({x},{y},{z});");
            });
        }
    }
}
