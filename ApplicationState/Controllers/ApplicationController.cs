using Microsoft.AspNetCore.Mvc;

namespace _01_ApplicationState.Controllers
{
    public class ApplicationController : Controller
    {
        // Статическое значение хранится в памяти приложения и удаляется в случае если выгружается приложение
        // Статическое значение является общим для всех пользователей

        private static int counter = 0;

        public IActionResult Index()
        {
            return View(counter);
        }

        public IActionResult Increase()
        {
            counter++;
            return RedirectToAction("Index");
        }

        public IActionResult Decrease()
        {
            counter--;
            return RedirectToAction("Index");
        }
    }
}