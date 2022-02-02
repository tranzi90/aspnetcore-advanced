using System;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationState.Controllers
{
    public class TempDataSampleController : Controller
    {
        const string tempDataKey = "mydata";

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string value)
        {
            // TempData - свойство, которое сохраняет состояние до момента, когда оно будет прочтено.
            // По умолчанию TempData сохраняется в cookies с использованием CookieTempDataProvider. Рекомендуется использовать такой подход для хранения данных до 500 байт.
            // Для смены провайдера необходимо вызвать метод AddSessionStateTempDataProvider на IMvcBuilder в классе Startup
            TempData[tempDataKey] = value;

            return View();
        }

        public IActionResult Test()
        {
            string value = Convert.ToString(TempData[tempDataKey]); // после чтения значение удаляется
            //string value = Convert.ToString(TempData.Peek(tempDataKey)); // после чтения значение остается

            return View(value as object);
        }
    }
}

