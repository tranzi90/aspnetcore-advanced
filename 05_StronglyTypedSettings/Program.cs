using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace _05_StronglyTypedSettings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.ConfigureAppConfiguration(config =>
                //{
                //    config.AddJsonFile("appsettings.json", true, true);
                //})
                .UseStartup<Startup>();
    }
}
