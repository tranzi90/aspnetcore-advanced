using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace _02_BranchingPipelines
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Данный метод конфигурирует два Pipeline
            /*
             1) UseDeveloperExceptionPage
             2) UseMvc    
             
             если запрос /health-check/*
             1) UseDeveloperExceptionPage
             2) UseExceptionHandler
             3) Run
            */
            app.UseDeveloperExceptionPage();

            app.Map("/health-check", branch => // /health-check ветка pipline
            {
                branch.UseExceptionHandler("/Error");

                branch.Run(async context =>
                {
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("OK");
                });
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                        name: "Default",
                        template: "{controller=home}/{action=index}"
                    );
            });
        }
    }
}
