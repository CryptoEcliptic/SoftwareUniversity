namespace IRunesWebApp.Services
{
    using IRunesWebApp.Services.Contracts;
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}
