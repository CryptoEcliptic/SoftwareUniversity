namespace BillsPaymentSystem.App.Core.Commands
{
    using BillsPaymentSystem.App.Core.Commands.Contracts;
    using BillsPaymentSystem.Data;
    using System;
    using System.Linq;
    using System.Text;

    public class PayBillsCommand : ICommandInterface
    {
        private readonly BillsPaymentSystemContext context;

        public PayBillsCommand(BillsPaymentSystemContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            int userId = int.Parse(args[0]);
            decimal amount = decimal.Parse(args[1]);

            var user = UserFinder.FindUser(userId, context);

            var bankAccounts = user
                .PaymentMethods
                .Select(x => x.BankAccount)
                .ToList();

            var creditCards = user
                .PaymentMethods
                .Select(x => x.CreditCard)
                .ToList();

            decimal totalUserAsset = 0;

            if (bankAccounts[0] != null)
            {
                totalUserAsset += bankAccounts.Sum(x => x.Balance);
                sb.AppendLine($"Initial bank account balance: {totalUserAsset}");
            }

            if (creditCards[0] != null)
            {
                totalUserAsset += creditCards.Sum(x => x.MoneyOwed);
                sb.AppendLine($"Initial credit card balance: {creditCards.Sum(x => x.MoneyOwed)}");
            }

            if (totalUserAsset < amount)
            {
                throw new ArgumentException("Insufficient funds!");
            }

            if (bankAccounts[0] != null)
            {
                amount = BankAccountPayment(sb, amount, bankAccounts);
            }

            if (creditCards[0] != null)
            {
                amount = CreditCardPayment(sb, amount, creditCards);
            }

            context.SaveChanges();
            sb.AppendLine("All bills are successfully payed!");
            return sb.ToString().TrimEnd();
        }

        private static decimal CreditCardPayment(StringBuilder sb, decimal amount, System.Collections.Generic.List<Models.CreditCard> creditCards)
        {
            foreach (var card in creditCards)
            {
                if (amount == 0)
                {
                    break;
                }

                if (card.MoneyOwed >= amount)
                {
                    card.MoneyOwed -= amount;
                    amount = 0;
                }

                else if (card.MoneyOwed < amount)
                {
                    amount = amount - card.MoneyOwed;
                    card.MoneyOwed = 0;
                }
            }
            sb.AppendLine($"Credit card balance after transaction: {creditCards.Sum(x => x.MoneyOwed)}");
            return amount;
        }

        private static decimal BankAccountPayment(StringBuilder sb, decimal amount, System.Collections.Generic.List<Models.BankAccount> bankAccounts)
        {
            foreach (var account in bankAccounts)
            {
                if (amount == 0)
                {
                    break;
                }

                if (account.Balance >= amount)
                {
                    account.Balance -= amount;
                    amount = 0;
                }

                else if (account.Balance < amount)
                {
                    amount = amount - account.Balance;
                    account.Balance = 0;
                }
            }
            sb.AppendLine($"Bank account balance after transaction: {bankAccounts.Sum(x => x.Balance)}");
            return amount;
        }
    }
}
