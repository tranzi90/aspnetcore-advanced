using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationState
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache(); // для хранения сессии в памяти и для использования кэширования (IMemoryCache)
            services.AddSession(); // для использования сессии
            //services.AddMvc();
            services.AddMvc().AddSessionStateTempDataProvider(); // TempData будет сохранятся в сессии
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSession(); // для использования сессии

            app.UseMvc(routes => routes.MapRoute(
                    name: "Default",
                    template: "{controller=home}/{action=index}/{id?}"
                ));
        }
    }
}
