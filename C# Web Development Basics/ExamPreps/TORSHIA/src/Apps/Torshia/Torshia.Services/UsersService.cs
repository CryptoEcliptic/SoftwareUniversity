using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Torshia.Data;
using Torshia.Data.Models;
using Torshia.Data.Models.Enums;

namespace Torshia.Services
{
    public class UsersService : IUsersService
    {
        private readonly TorshiaDbContext context;

        public UsersService(TorshiaDbContext context)
        {
            this.context = context;
        }

        public void CreateUser(string username, string email, string password)
        {
            var hashedPassword = ComputeSha256Hash(password);

            var role = this.context.Users.Any() ? UserRole.User : UserRole.Admin;

            var user = new User
            {
                Username = username,
                Email = email,
                Password = hashedPassword,
                Role = role  
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            var hashedPassword = ComputeSha256Hash(password);

            var user = this.context.Users.FirstOrDefault(x => x.Username == username
            && x.Password == hashedPassword);

            return user;
        }

        public List<User> GerUsersByUsernames(string[] usernames)
        {
            List<User> users = new List<User>();

            foreach (var username in usernames)
            {
                var currentUser = this.context.Users.FirstOrDefault(x => x.Username == username);

                if (currentUser != null)
                {
                    users.Add(currentUser);
                }
            }

            return users;
        }
        private static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
