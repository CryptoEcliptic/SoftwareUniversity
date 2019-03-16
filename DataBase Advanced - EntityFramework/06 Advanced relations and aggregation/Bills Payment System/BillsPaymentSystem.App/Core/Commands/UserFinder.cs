namespace BillsPaymentSystem.App.Core.Commands
{
    using BillsPaymentSystem.Data;
    using BillsPaymentSystem.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public static class UserFinder
    {
    
        public static User FindUser(int userId, BillsPaymentSystemContext context)
        {
            var user = context
                .Users
                .Include(u => u.PaymentMethods)
                .ThenInclude(pm => pm.BankAccount)
                .Include(u => u.PaymentMethods)
                .ThenInclude(pm => pm.CreditCard)
                .FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                throw new ArgumentException(null, "No such user in the database!");
            }

            return user;
        }
    }
}
