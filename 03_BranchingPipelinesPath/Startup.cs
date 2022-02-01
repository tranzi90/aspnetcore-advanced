using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace _03_BranchingPipelinesPath
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Метод Map модифицирует путь отрезая первые сегменты запроса, если они совпадают с первым параметром метода map
            // Это позволяет перенести в ветку MVC middleware не выполняя дополнительных настроек маршрутизации

            app.Map("/path1", branch =>
            {
                branch.Run(async context =>
                {
                    string path = context.Request.Path;
                    string pathBase = context.Request.PathBase;

                    await context.Response.WriteAsync($"Path1 branch. Path: {path}, PathBase: {pathBase}");
                });
            });

            app.Map("/path2/path3", branch =>
            {
                branch.Run(async context =>
                {
                    string path = context.Request.Path;
                    string pathBase = context.Request.PathBase;

                    await context.Response.WriteAsync($"Path2 branch. Path: {path}, PathBase: {pathBase}");
                });
            });

            app.Run(async context =>
            {
                string path = context.Request.Path;
                string pathBase = context.Request.PathBase;

                await context.Response.WriteAsync($"Main branch. Path: {path}, PathBase: {pathBase}");
            });

        }
    }
}
