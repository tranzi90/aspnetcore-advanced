using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace _05_StronglyTypedSettings.Controllers
{
    public class ThirdController : Controller
    {
        // IOptionsSnapshot позволяет получать обновленные данные из файла конфигурации без перезапуска приложения
        public ThirdController(IOptionsSnapshot<RepostSettings> repostSettings)
        {
            RepostSettings = repostSettings;
        }

        public IOptionsSnapshot<RepostSettings> RepostSettings { get; }

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