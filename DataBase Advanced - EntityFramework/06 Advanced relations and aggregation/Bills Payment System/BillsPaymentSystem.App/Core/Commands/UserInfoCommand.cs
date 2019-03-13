namespace BillsPaymentSystem.App.Core.Commands
{
    using BillsPaymentSystem.App.Core.Commands.Contracts;
    using BillsPaymentSystem.Data;
    using BillsPaymentSystem.Models;
    using BillsPaymentSystem.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class UserInfoCommand : ICommandInterface
    {
        private readonly BillsPaymentSystemContext context;

        public UserInfoCommand(BillsPaymentSystemContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            int userId = int.Parse(args[0]);


            if (!context.Users.Any(x => x.UserId == userId))
            {
                throw new ArgumentNullException(null, $"User with id {userId}" +
                    $" not found!");
            }

            var user = context.Users
                      .Where(x => x.UserId == userId)
                      .Select(x => new
                      {
                         x.FirstName,
                         x.LastName,
                          BankAccounts = x.PaymentMethods
                              .Where(y => y.Type == PaymentMethodType.BankAccount)
                              .Select(y => y.BankAccount)
                              .ToList(),
                          CreditCards = x.PaymentMethods
                              .Where(y => y.Type == PaymentMethodType.CreditCard)
                              .Select(y => y.CreditCard)
                              .ToList()
                      })
                      .FirstOrDefault();


            List<BankAccount> bankAccounts = user.BankAccounts.ToList();
            List<CreditCard> creditCards = user.CreditCards.ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"User: {user.FirstName} {user.LastName}");

            sb.AppendLine($"Bank Accounts:");
            if (bankAccounts.Count >= 1)
            {
                foreach (var account in bankAccounts)
                {
                    sb.AppendLine($"--ID: {account.BankAccountId}");
                    sb.AppendLine($"--- Balance: {account.Balance:f2}");
                    sb.AppendLine($"--- Bank: {account.BankName}");
                    sb.AppendLine($"--- SWIFT: {account.SWIFT}");
                }
            }
            else if (!bankAccounts.Any())
            {
                sb.AppendLine("That user does not possess bank accounts!");
            }

            sb.AppendLine($"Credit Cards:");

            if (creditCards.Count >= 1)
            {
                foreach (var card in creditCards)
                {
                    sb.AppendLine($"-- ID: {card.CreditCardId}");
                    sb.AppendLine($"--- Limit: {card.Limit:f2}");
                    sb.AppendLine($"--- Money Owed: {card.MoneyOwed:f2}");
                    sb.AppendLine($"--- Limit Left: {card.LimitLeft:f2}");
                    sb.AppendLine($"--- Expiration Date: {card.ExpirationDate.ToString("yyyy/mm", CultureInfo.InvariantCulture)}");
                }
            }

            else if (!creditCards.Any())
            {
                sb.AppendLine("That user does not possess Credit Cards!");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
