using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace _08_EnvironmentSpecificConfig
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    var env = hostContext.HostingEnvironment;
                    config
                        .AddJsonFile("appsettings.json", optional: false)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

                    if (env.IsDevelopment())
                    {
                        // дополнительные настройки для окружения разработки
                    }
                })
                .UseStartup<Startup>();
    }
}
