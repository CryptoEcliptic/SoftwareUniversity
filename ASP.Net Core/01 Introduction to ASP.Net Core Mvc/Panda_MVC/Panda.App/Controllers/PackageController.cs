using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Panda.App.Data;
using Panda.App.Domains;
using Panda.App.Models.Package;
using Panda.App.Services;
using System;
using System.Globalization;
using System.Linq;

namespace Panda.App.Controllers
{
    public class PackageController : Controller
    {
        private const decimal priceIndex = 2.67m;
        private readonly PandaDbContext context;
        private readonly IPackageService packageService;
        private static readonly Random getrandom = new Random();

        public PackageController(PandaDbContext context, IPackageService packageService)
        {
            this.context = context;
            this.packageService = packageService;
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            this.ViewData["Recipients"] = this.context.Users.ToList();
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(PackageCreateBindingModel bindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Package/Create");
            }

            var isPackageCreated = this.packageService.CreatePackage(bindingModel);

            if (!isPackageCreated)
            {
                return this.Redirect("/Package/Create");
            }

            return this.Redirect("/Package/Pending");

        }

        [HttpGet]
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
                Description = package.Description,
            };
 
            if (package.Status == PackageStatus.Pending)
            {
                detailsModel.EstimatedDeliveryDate = "N/A";
            }
            else if (package.Status == PackageStatus.Shipped)
            {
                detailsModel.EstimatedDeliveryDate = package.EstimatedDeliveryDate.Value.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                detailsModel.EstimatedDeliveryDate = "Delivered";
            }

            return this.View(detailsModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
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
                .OrderBy(x => x.Id)
                .ToList();
               ;
            return this.View( new PendingPackagesListViewModel { PendingPackages = pendingPackages });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
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
                .OrderBy(x => x.EstimatedDeliveryDate)
                .ToList();
            ;
            return this.View(new ShippedPackageListViewModel { ShippedPackages = shippedPackages });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delivered()
        {
            var deliveredPackages = this.context.Packages
                .Where(x => x.Status == PackageStatus.Delivered || x.Status == PackageStatus.Acquired)
                .Select(x => new DeliveredPackageViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    ShippingAddress = x.ShippingAddress,
                    Weight = x.Weight,
                    Recipient = x.Recipient.UserName
                })
                .OrderByDescending(x => x.Id)
                .ToList();
            ;
            return this.View(new DeliveredPackageListViewModel { DeliveredPackages = deliveredPackages });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Ship(int id)
        {
            var packageToShip = this.context.Packages.FirstOrDefault(x => x.Id == id);
            packageToShip.Status = PackageStatus.Shipped;
            packageToShip.EstimatedDeliveryDate = DateTime.UtcNow.AddDays(GetRandomNumber(20, 40));
            this.context.Update(packageToShip);
            this.context.SaveChanges();

            return this.Redirect("/Package/Pending");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Deliver(int id)
        {
            var packageToDeliver = this.context.Packages.FirstOrDefault(x => x.Id == id);
            packageToDeliver.Status = PackageStatus.Delivered;
            packageToDeliver.EstimatedDeliveryDate = DateTime.UtcNow.AddDays(GetRandomNumber(20, 40));
            this.context.Update(packageToDeliver);
            this.context.SaveChanges();

            return this.Redirect("/Package/Shipped");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Acquire(int id)
        {
            var packageToAcquire = this.context.Packages.FirstOrDefault(x => x.Id == id);
            packageToAcquire.Status = PackageStatus.Acquired;
            this.context.Update(packageToAcquire);
            this.context.SaveChanges();
            var user = this.context.Users.FirstOrDefault(x => x.UserName == this.User.Identity.Name);


            var receipt = new Receipt
            {
                Fee = packageToAcquire.Weight * priceIndex,
                IssuedOn = DateTime.UtcNow,
                Package = packageToAcquire,
                Recipient = (PandaUser)user,
            };

            this.context.Receipts.Add(receipt);
            this.context.SaveChanges();
            return this.Redirect("/Home/Index");
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