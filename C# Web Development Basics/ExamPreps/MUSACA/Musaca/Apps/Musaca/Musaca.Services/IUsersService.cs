using Musaca.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Musaca.Services
{
    public interface IUsersService
    {
        User CreateUser(string username, string email, string password);

        User GetUserByUsernameAndPassword(string username, string password);

        List<string> GetAllUsernames();

        User GetById(string id);

        IQueryable<Order>ShowAllUsersOrders(string userId);
    }
}
