using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationState.Controllers
{
    public class SessionSampleController : Controller
    {
        private const string sessionKey = "mydata";

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string value)
        {
            // Для использования сессии необходимо зарегистрировать сервисы через AddSession и подключить middleware через UseSession в классе Startup
            HttpContext.Session.SetString(sessionKey, value);

            return View();
        }

        public IActionResult Test()
        {
            string value = HttpContext.Session.GetString(sessionKey);
            return View(value as object);
        }
    }
}