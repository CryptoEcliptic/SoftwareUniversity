using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Torshia.Data.Models;

namespace Torshia.Services
{
    public interface IUsersService
    {
        void CreateUser(string username, string email, string password);

        User GetUserByUsernameAndPassword(string username, string password);

       List<User> GerUsersByUsernames(string[] usernames);

    }
}
