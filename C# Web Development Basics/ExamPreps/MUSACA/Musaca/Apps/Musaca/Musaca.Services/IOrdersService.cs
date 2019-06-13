using Musaca.Data.Models;
using System.Linq;

namespace Musaca.Services
{
    public interface IOrdersService
    {
        Order CreateOrder(string id);
        void AddProductToOrder(string name, string orderId);
        void CahsoutCurrentOrder(string userId);
    }
}
