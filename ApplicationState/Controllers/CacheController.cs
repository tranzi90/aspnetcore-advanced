using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading;

namespace _01_ApplicationState.Controllers
{
    public class CacheController : Controller
    {
        private readonly IMemoryCache memoryCache;

        public CacheController(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            if (!memoryCache.TryGetValue("saved_list", out object value))
            {
                value = LoadData();
                // Вариант 1
                // Сохранение в кэш без определения времени жизни записи. Кэш является общим для всех пользователей.
                memoryCache.Set("saved_list", value);

                // Вариант 2
                // Cохранение в кэш на 10 секунд (использование абсолютного времени устаревания). 
                //memoryCache.Set("saved_list", value, TimeSpan.FromSeconds(10));

                // Вариант 3
                // Сохранение в кэш на 5 секунд (используя скользящее время устаревания). Данные удалятся из кэш, если последнее обращение произошло более 5 секунд назад.
                //memoryCache.Set("saved_list", value, new MemoryCacheEntryOptions() { SlidingExpiration = TimeSpan.FromSeconds(5) });
            }
            return View(value);

        }

        public string[] LoadData()
        {
            Thread.Sleep(3000);

            string[] data = new string[] {
                "First",
                "Second",
                "Third"
            };

            return data;
        }
    }
}