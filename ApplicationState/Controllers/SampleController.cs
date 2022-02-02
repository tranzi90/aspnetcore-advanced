using Microsoft.AspNetCore.Mvc;

namespace ApplicationState.Controllers
{
    public class SampleController : Controller
    {
        // На запрос к каждому методу действия создается новый экземпляр контроллера.
        // Поле controllerState содержит состояние во время обработки запроса, но при следующем запросе 
        // значение поля будет равно значению по умолчанию
        private string controllerState;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string value)
        {
            controllerState = value;
            return View();
        }

        public IActionResult Test()
        {
            return View(controllerState as object);
        }
    }
}