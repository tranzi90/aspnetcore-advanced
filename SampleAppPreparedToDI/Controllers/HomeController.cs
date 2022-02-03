using _01_SampleApp.Classes;
using Microsoft.AspNetCore.Mvc;

namespace _02_SampleAppPreparedToDI.Controllers
{
    public class HomeController : Controller
    {
        // Вместо создания зависимости она внедряется через конструктор
        // Экземпляр класса Messanger в контексте DI называется сервисом. Сервис любой экземпляр, который был создан DI контейнером по требованию.
        // ДАННЫЙ КОД НЕ РАБОТАЕТ, ТАК КАК НЕ НАСТРОЕН DI КОНТЕЙНЕР

        private Messanger _messanger;
        public HomeController(Messanger messanger)
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
            // Проблема данного кода в том, что он остался зависимым от реализации. 
            // Чтобы добавить возможность подмены класса Messanger, на stub или mock объект для тестирования
            // или возможность подставлять другие реализации, например, такую, которая генерирует HTML разметку в ответ
            // данный код должен быть завязан на интерфейс.
            _messanger.SendMessage(message, "admin@example.com");

            return View();
        }
    }
}