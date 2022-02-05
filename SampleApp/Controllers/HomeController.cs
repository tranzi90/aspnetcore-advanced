using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SampleApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            List<string> list = new List<string>();
            list.Add("element 1");
            list.Add("element 2");
            list.Add("element 3");
            list.Add("element 4");

            return View(list);
        }
    }
}