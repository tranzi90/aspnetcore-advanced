using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace _05_StronglyTypedSettings.Controllers
{
    public class FirstController : Controller
    {
        public FirstController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IActionResult Index()
        {
            string title = Configuration["MainPage:Title"];
            int count = Convert.ToInt32(Configuration["Posts:Count"]);
            string theme = Configuration["Posts:Theme"];
            bool repostEnabled = Convert.ToBoolean(Configuration["Posts:RepostSettings:Enabled"]);
            bool facebookEnabled = Convert.ToBoolean(Configuration["Posts:RepostSettings:Facebook"]);
            bool twitterEnabled = Convert.ToBoolean(Configuration["Posts:RepostSettings:Twitter"]);

            return View();
        }
    }
}