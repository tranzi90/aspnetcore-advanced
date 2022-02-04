using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace _02_MultipleProviders
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                // Для данного приложения будут использоваться три источника данных
                // провайдер, загруженный позже будет перезаписывать данные с идентичными ключами провайдеров, которые загружались ранее
                .ConfigureAppConfiguration(config =>
                {
                    config.AddJsonFile("shared.json", optional: true);
                    config.AddJsonFile("appsettings.json", optional: true);
                    config.AddEnvironmentVariables(); // добавление переменных окружения
                })
                .UseStartup<Startup>();
    }
}

