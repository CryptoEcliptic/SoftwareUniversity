using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Panda.App.Data;
using Panda.App.Domains;
using Panda.App.Models.Package;

namespace Panda.App.Services
{
    public class PackageService : IPackageService
    {
        private readonly PandaDbContext context;

        public PackageService(PandaDbContext context)
        {
            this.context = context;
        }

        public bool CreatePackage(PackageCreateBindingModel bindingModel)
        {
            var recipient = this.context.Users.FirstOrDefault(x => x.UserName == bindingModel.Recipient);

            if (recipient == null)
            {
                return false;
            }

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

            return true;
        }
    }
}
