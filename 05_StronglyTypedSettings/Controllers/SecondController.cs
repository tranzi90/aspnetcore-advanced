using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace _05_StronglyTypedSettings.Controllers
{
    public class SecondController : Controller
    {
        // RepostSettings мапинг объекта на секцию файла конфигурации происходит в классе Startup
        // Данные из файла конфигурации считываются один раз при старте приложения
        public SecondController(IOptions<RepostSettings> repostSettings, IOptions<MainSettings> mainSettings)
        {
            RepostSettings = repostSettings;
            MainSettings = mainSettings;
        }

        public IOptions<RepostSettings> RepostSettings { get; }
        public IOptions<MainSettings> MainSettings { get; }

        public IActionResult Index()
        {
            RepostSettings settings = RepostSettings.Value;

            bool enabled = settings.Enabled;
            bool facebook = settings.Facebook;
            bool twitter = settings.Twitter;

            return View();
        }
    }
}