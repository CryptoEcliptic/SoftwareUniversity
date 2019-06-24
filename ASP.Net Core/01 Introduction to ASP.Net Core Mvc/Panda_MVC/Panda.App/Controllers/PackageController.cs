using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Panda.App.Data;
using Panda.App.Domains;
using Panda.App.Models.Package;
using System;
using System.Globalization;
using System.Linq;

namespace Panda.App.Controllers
{
    public class PackageController : Controller
    {
        private readonly PandaDbContext context;
        private static readonly Random getrandom = new Random();

        public PackageController(PandaDbContext context)
        {
            this.context = context;
        }

        [Authorize]
        public IActionResult Create()
        {
            this.ViewData["Recipients"] = this.context.Users.ToList();
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(PackageCreateBindingModel bindingModel)
        {
            var recipient = this.context.Users.FirstOrDefault(x => x.UserName == bindingModel.Recipient);
            var package = new Package
            {
                Description = bindingModel.Description,
                Weight = bindingModel.Weight,
                ShippingAddress = bindingModel.ShippingAddress,
                Status = PackageStatus.Pending,
                Recipient = (PandaUser)recipient,
                EstimatedDeliveryDate = null
            };

            this.context.Packages.Add(package);
            this.context.SaveChanges();

            return this.Redirect("/Package/Pending");

        }

        [Authorize]
        public IActionResult Details(int id)
        {

            var package = this.context.Packages
                .FirstOrDefault(x => x.Id == id)
                ;
            var recipient = this.context.Users
                .FirstOrDefault(x => x.Id == package.RecipientId);

            var detailsModel = new PackageDetailsViewModel
            {
                Address = package.ShippingAddress,
                Weight = package.Weight,
                Recipient = recipient.UserName,
                Status = package.Status.ToString(),
                Description = package.Description
            };
 
            if (package.Status == PackageStatus.Pending)
            {
                detailsModel.EstimatedDeliveryDate = "N/A";
            }
            else if (package.Status == PackageStatus.Shipped)
            {
                detailsModel.EstimatedDeliveryDate = DateTime.UtcNow.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                detailsModel.EstimatedDeliveryDate = "Delivered";
            }

            return this.View(detailsModel);
        }

        [Authorize]
        public IActionResult Pending()
        {
            var pendingPackages = this.context.Packages
                .Where(x => x.Status == PackageStatus.Pending)
                .Select(x => new PendingPackageViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    ShippingAddress = x.ShippingAddress,
                    Weight = x.Weight,
                    Recipient = x.Recipient.UserName
                })
                .ToList();
               ;
            return this.View( new PendingPackagesListViewModel { PendingPackages = pendingPackages });
        }

        [Authorize]
        public IActionResult Shipped()
        {
            var shippedPackages = this.context.Packages
                .Where(x => x.Status == PackageStatus.Shipped)
                .Select(x => new ShippedPackageVewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    EstimatedDeliveryDate = x.EstimatedDeliveryDate.Value.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Weight = x.Weight,
                    Recipient = x.Recipient.UserName
                })
                .ToList();
            ;
            return this.View(new ShippedPackageListViewModel { ShippedPackages = shippedPackages });
        }

        [Authorize]
        public IActionResult Delivered()
        {
            var deliveredPackages = this.context.Packages
                .Where(x => x.Status == PackageStatus.Delivered)
                .Select(x => new DeliveredPackageViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    ShippingAddress = x.ShippingAddress,
                    Weight = x.Weight,
                    Recipient = x.Recipient.UserName
                })
                .ToList();
            ;
            return this.View(new DeliveredPackageListViewModel { DeliveredPackages = deliveredPackages });
        }


        [Authorize]
        public IActionResult Ship(int id)
        {
            var packageToShip = this.context.Packages.FirstOrDefault(x => x.Id == id);
            packageToShip.Status = PackageStatus.Shipped;
            packageToShip.EstimatedDeliveryDate = DateTime.UtcNow.AddDays(GetRandomNumber(20, 40));
            this.context.Update(packageToShip);
            this.context.SaveChanges();

            return this.Redirect("/Package/Pending");
        }

        [Authorize]
        public IActionResult Deliver(int id)
        {
            var packageToDeliver = this.context.Packages.FirstOrDefault(x => x.Id == id);
            packageToDeliver.Status = PackageStatus.Delivered;
            packageToDeliver.EstimatedDeliveryDate = DateTime.UtcNow.AddDays(GetRandomNumber(20, 40));
            this.context.Update(packageToDeliver);
            this.context.SaveChanges();

            return this.Redirect("/Package/Shipped");
        }

        [NonAction]
        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) 
            {
                return getrandom.Next(min, max);
            }
        }
    }
}