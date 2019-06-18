using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FDMC.Models;
using FDMC.Service;
using FDMC.Models.Cats;

namespace FDMC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICatsService catsService;

        public HomeController(ICatsService catsService)
        {
            this.catsService = catsService;
        }

        public IActionResult Index()
        {
            var cats = this.catsService.GetAllCats().Select(x => new CatsBasicInfo
            {
                Id = x.Id,
                Name = x.Name

            })
            .ToList();

            return View(new AllCatsViewModel { Cats = cats });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
