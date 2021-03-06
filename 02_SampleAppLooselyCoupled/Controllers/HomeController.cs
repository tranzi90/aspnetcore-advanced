using _03_SampleAppLooselyCoupled.Classes;
using Microsoft.AspNetCore.Mvc;

namespace _02_SampleAppLooselyCoupled.Controllers
{
    public class HomeController : Controller
    {
        private IMessanger _messanger;
        public HomeController(IMessanger messanger)
        {
            _messanger = messanger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string message)
        {
            // Регистрация сервисов в DI контейнере происходит в классе Strtup.cs
            _messanger.SendMessage(message, "admin@example.com");

            return View();
        }
    }
}