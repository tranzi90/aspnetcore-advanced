using _06_AutomaticBindnig.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace _06_AutomaticBindnig.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IOptions<MainSettings> mainSettings)
        {
            MainSettings = mainSettings;
        }

        public IOptions<MainSettings> MainSettings { get; }

        public IActionResult Index()
        {
            return View();
        }
    }
}