using Panda.Data;
using Panda.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Panda.Services
{
    public class UserService : IUsersService
    {
        private readonly PandaDbContext context;

        public UserService(PandaDbContext context)
        {
            this.context = context;
        }

        public User CreateUser(string username, string email, string password)
        {
            var hashedPassword = ComputeSha256Hash(password);
            var user = new User
            {
                Username = username,
                Email = email,
                Password = hashedPassword
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();

            return user;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            var hashedPassword = ComputeSha256Hash(password);

            var user = this.context.Users.FirstOrDefault(x => x.Username == username 
            && x.Password == hashedPassword);

            return user;
        }

        public List<string> GetAllUsernames()
        {
            return this.context.Users.Select(x => x.Username).ToList();
        }

        public User GetById(string id)
        {
            return this.context.Users.FirstOrDefault(x => x.Id == id);
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
