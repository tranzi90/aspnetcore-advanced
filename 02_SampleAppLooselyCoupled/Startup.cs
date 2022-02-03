using _02_SampleAppLooselyCoupled.Classes;
using _03_SampleAppLooselyCoupled.Classes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace _02_SampleAppLooselyCoupled
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddScoped<IMessanger, Messanger>();    // при запросе типа IMessanger использовать Messanger
            services.AddScoped<MessageFactory>();           // при запросе типа MessageFactory использовать MessageFactory
            services.AddScoped<SmtpClient>();               // при запросе типа SmtpClient использовать SmtpClient
            services.AddScoped<SmtpSettings>(provider =>    // при запросе типа SmtpSettings использовать SmtpSettings с указанными параметрами
            {
                return new SmtpSettings() { Host = "smtp.example.com", Port = 25 };
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

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
