using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Panda.Data;
using Panda.Data.Models;
using Panda.Data.Models.Enums;

namespace Panda.Services
{
    public class PackageService : IPackageService
    {
        private readonly PandaDbContext context;
        private readonly IReceiptsService receiptService;

        public PackageService(PandaDbContext context, IReceiptsService receiptService)
        {
            this.context = context;
            this.receiptService = receiptService;
        }

        public Package CreatePackage(string description, decimal weight, string shippingAddress, string username)
        {
            var recipient = this.context.Users.FirstOrDefault(x => x.Username == username);

            if (recipient == null)
            {
                return null;
            }

            var package = new Package
            {
                Description = description,
                Weight = weight,
                ShippingAddress = shippingAddress,
                Recipient = recipient,
                Status = PackageStatus.Pending
            };

            context.Packages.Add(package);
            context.SaveChanges();

            return package;
        }

        
        public IQueryable<Package> GetAllPengingPackages()
        {
            var pending = this.context.Packages
                .Where(x => x.Status == PackageStatus.Pending)
                ;

            return pending;
        }

        public bool DeliverPackage(string id)
        {
            var package = this.context.Packages.FirstOrDefault(x => x.Id == id);

            package.Status = PackageStatus.Delivered;

            this.context.Update(package);
            this.context.SaveChanges();

            this.receiptService.CreateReceipt(package.Weight, package.RecipientId, package.Id);

            return true;
        }

        public IQueryable<Package> GetAllDeliveredPackages()
        {
            var delivered = this.context.Packages
                .Where(x => x.Status == PackageStatus.Delivered)
                ;
            return delivered;
        }
    }
}
