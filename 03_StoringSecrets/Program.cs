using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace _03_StoringSecrets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            // При использовании ASP.NET Core User Secrets добавляются автоматически при запуске проекта в Development окружении
            // Для редактирования секретов текущего приложения используйте пункт контекстного меню Manage User Secret на текущем проекте
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(config =>
                {
                    config.AddEnvironmentVariables();
                    // Id секрета находиться в csproj файле
                    // секреты добавляются по умолчанию, если проект запускается с Development конфигурацией ("ASPNETCORE_ENVIRONMENT": "Development")
                    // пример явного определения секретов для текущей конфигурации
                    // config.AddUserSecrets("ce0b4330-4258-4bf4-b9aa-2891772e47cc");
                })
                .UseStartup<Startup>();
    }
}