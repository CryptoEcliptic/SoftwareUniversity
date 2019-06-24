using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Panda.App.Data;
using Panda.App.Models.Receipt;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.App.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly PandaDbContext context;

        public ReceiptsController(PandaDbContext context)
        {
            this.context = context;
        }

        [Authorize]
        public IActionResult My()
        {
            var usersReceipts = this.context.Receipts
                .Where(x => x.Recipient.UserName == this.User.Identity.Name)
                .Select(x => new ReceiptIndexViewModel {
                    Id = x.Id,
                    Fee = x.Fee,
                    IssuedOn = x.IssuedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Recipient = x.Recipient.UserName
                })
                .ToList();

            return this.View(new MyReceiptsListViewModel { Receipts = usersReceipts });
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var receipt = this.context.Receipts.FirstOrDefault(x => x.Id == id);
            var package = this.context.Packages
                .Include(x => x.Receipt)
                .ThenInclude(x => x.Recipient)
                .FirstOrDefault(x => x.Receipt.Id == id);
            //var recipient = this.context.Users.FirstOrDefault(x => x.Id == package.RecipientId);
            if (receipt != null && package != null)
            {
                var detailsModel = new ReceiptDetailsViewModel
                {
                    DeliveryAddress = package.ShippingAddress,
                    IssuedOn = receipt.IssuedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    PackageDescription = package.Description,
                    PackageWeight = package.Weight,
                    ReceiptNumber = receipt.Id,
                    Recipient = package.Recipient.UserName,
                    Total = receipt.Fee
                };

                return this.View(detailsModel);
            }
            return this.View();
        }
    }
}
