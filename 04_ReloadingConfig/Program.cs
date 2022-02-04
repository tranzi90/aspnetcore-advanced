using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace _04_ReloadingConfig
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(config =>
                {
                    config.AddJsonFile("config1.json", optional: true)                  // не обязательный файл, обновляется при старте приложения
                    .AddJsonFile("config2.json")                                        // обязательный файл, обновляется при старте приложения
                    .AddJsonFile("config3.json", optional: true, reloadOnChange: true); // не обязательный файл, обновляется при изменении в файле
                })
                .UseStartup<Startup>();
    }
}
