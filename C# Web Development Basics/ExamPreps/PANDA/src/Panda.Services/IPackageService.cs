using Panda.Data.Models;
using System.Linq;

namespace Panda.Services
{
    public interface IPackageService
    {
        bool CreatePackage(string description, decimal weight, string shippingAddress, string username);

        IQueryable<Package> GetAllPengingPackages();

        bool DeliverPackage(string id);

        IQueryable<Package> GetAllDeliveredPackages();
    }
}
