using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace _01_ApplicationState.Controllers
{
    public class CatalogController : Controller
    {
        Dictionary<int, string> data;

        public CatalogController()
        {
            data = new Dictionary<int, string>();
            data[1] = "first";
            data[2] = "second";
            data[3] = "third";
        }

        public IActionResult Index()
        {
            return View(data);
        }

        public IActionResult Details(int id)
        {
            string value = data[id];
            return View((object)value);
        }
    }
}