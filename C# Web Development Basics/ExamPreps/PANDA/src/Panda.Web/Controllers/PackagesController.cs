using Panda.Services;
using Panda.Web.ViewModels.Packages;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.Web.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IUsersService userService;
        private readonly IPackageService packageService;

        [Authorize]
        public PackagesController(IUsersService userService, IPackageService packageService)
        {
            this.userService = userService;
            this.packageService = packageService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var usernames = this.userService.GetAllUsernames();

            return this.View(usernames);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreatePackageViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Packages/Create");
            }

            var package = this.packageService.CreatePackage(model.Description, model.Weight, model.ShippingAddress, model.RecipientName);

            if (package == null)
            {
                return this.Redirect("/Packages/Create");
            }

            return this.Redirect("/Packages/Pending");
        }

        [Authorize]
        public IActionResult Pending()
        {
            var pendingPackages = this.packageService.GetAllPengingPackages()
                .Select(x => new PendingViewModel
                {
                    Description = x.Description,
                    RecipientName = x.Recipient.Username,
                    Weight = x.Weight,
                    ShippingAddress = x.ShippingAddress,
                    Id = x.Id
                }).ToList();

            return this.View(new PendingPackagesList { Packages = pendingPackages});
        }

        [Authorize]
        public IActionResult Deliver(string id)
        {          
            if (this.packageService.DeliverPackage(id))
            {
                return this.Redirect("/Packages/Delivered");
            }

            return this.Redirect("/Packages/Pending");
        }

        [Authorize]
        public IActionResult Delivered()
        {
            var deliveredPackages = this.packageService.GetAllDeliveredPackages()
                .Select(x => new DeliveredViewModel
                {
                    Description = x.Description,
                    RecipientName = x.Recipient.Username,
                    Weight = x.Weight,
                    ShippingAddress = x.ShippingAddress,

                }).ToList();

            return this.View(new DeliveredPackagesList { Packages = deliveredPackages });
        }
    }
}
