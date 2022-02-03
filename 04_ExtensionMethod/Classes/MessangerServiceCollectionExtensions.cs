using Microsoft.Extensions.DependencyInjection;
using SampleAppLooselyCoupled.Classes;

namespace _04_ExtensionMethod.Classes
{
    public static class MessangerServiceCollectionExtensions
    {
        public static IServiceCollection AddMessanger(this IServiceCollection services)
        {
            services.AddScoped<IMessanger, Messanger>();    // при запросе типа IMessanger использовать Messanger
            services.AddScoped<MessageFactory>();           // при запросе типа MessageFactory использовать MessageFactory
            services.AddScoped<SmtpClient>();               // при запросе типа SmtpClient использовать SmtpClient
            services.AddScoped(provider =>                  // при запросе типа SmtpSettings использовать SmtpSettings с указанными параметрами
            {
                return new SmtpSettings() { Host = "smtp.example.com", Port = 25 };
            });

            return services; // по соглашению метод должен возвращать IServiceCollection для возможности использования цепочки вызовов
        }
    }
}
