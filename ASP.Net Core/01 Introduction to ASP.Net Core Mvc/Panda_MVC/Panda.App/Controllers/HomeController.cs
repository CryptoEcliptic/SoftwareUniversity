using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Panda.App.Data;
using Panda.App.Models;

namespace Panda.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly PandaDbContext context;

        public HomeController(PandaDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            this.ViewData["Pending"] = this.context.Packages
                .Where(x => x.Status == Domains.PackageStatus.Pending && x.Recipient.UserName == this.User.Identity.Name
               ).ToList();

            this.ViewData["Shipped"] = this.context.Packages.Where(x => x.Status == Domains.PackageStatus.Shipped && x.Recipient.UserName == this.User.Identity.Name).ToList();
            this.ViewData["Delivered"] = this.context.Packages.Where(x => x.Status == Domains.PackageStatus.Delivered && x.Recipient.UserName == this.User.Identity.Name).ToList();

            return View();
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
