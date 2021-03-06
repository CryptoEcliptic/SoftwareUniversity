﻿using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;

namespace Torshia.App.Controllers
{
    class HomeController : Controller
    {
        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {

                return this.View("IndexLoggedIn");
            }

            return this.View();
        }
        //TODO Implement LoggedIn View
    }
}
