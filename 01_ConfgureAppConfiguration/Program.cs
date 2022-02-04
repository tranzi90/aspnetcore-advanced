using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace _01_ConfgureAppConfiguration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                // определение JSON провайдера для чтения файла appsettings.json файла
                //.ConfigureAppConfiguration(config =>
                //{
                //    config.AddJsonFile("appsettings.json", optional: true);
                //})
                .UseStartup<Startup>();

    }
}
