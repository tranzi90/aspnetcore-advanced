using _01_SampleApp.Classes;
using Microsoft.AspNetCore.Mvc;

namespace _01_SampleApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string message)
        {
            // Класс Messanger зависит от классов MessageFactory и SmtpClient, в то же время класс SmtpClient зависит от класса SmtpSettings

            // Данный код имеет ряд проблем:
            // 1) Не придерживается принципов single responsibility - данный код отвечает, как за создание Messanger так и за его использование
            // 2) Много кода, который не выполняет бизнес задач, а только подготавливает код для работы. Полезными являются только две последние строчки кода в методе.
            // 3) При рефакторинге класса Messanger нужно будет вносить изменения во всех участках кода, где использовался данный класс.

            // Задача DI построить граф зависимостей таким образом чтобы зависимости создавались за пределами класса, который их использует.
            // DI container - компонент, который отвечает за создание зависимостей и передачу зависимостей в конструктор.

            var messageFactory = new MessageFactory();
            var settings = new SmtpSettings()
            {
                Host = "smtp.example.com",
                Port = 25
            };
            var smtpClient = new SmtpClient(settings);
            var messanger = new Messanger(smtpClient, messageFactory);

            messanger.SendMessage(message, "admin@example.com");

            return View();
        }
    }
}

