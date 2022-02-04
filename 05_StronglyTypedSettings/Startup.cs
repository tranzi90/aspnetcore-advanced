using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _05_StronglyTypedSettings
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
            services.AddMvc();

            // Определение связей между классами и секциями файла конфигурации
            services.Configure<MainSettings>(Configuration.GetSection("MainPage"));
            services.Configure<PostSettings>(Configuration.GetSection("Posts"));
            services.Configure<RepostSettings>(Configuration.GetSection("Posts:RepostSettings"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "Default", template: "{controller=first}/{action=index}");
            });
        }
    }
}
