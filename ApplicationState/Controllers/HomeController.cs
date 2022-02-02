using Microsoft.AspNetCore.Mvc;

namespace ApplicationState.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}