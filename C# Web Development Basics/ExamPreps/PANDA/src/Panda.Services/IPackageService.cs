using Panda.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.Services
{
    public interface IPackageService
    {
        Package CreatePackage(string description, decimal weight, string shippingAddress, string username);

        IQueryable<Package> GetAllPengingPackages();

        bool DeliverPackage(string id);

        IQueryable<Package> GetAllDeliveredPackages();
    }
}
