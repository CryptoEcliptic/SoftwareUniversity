namespace BillsPaymentSystem.App.Core.Commands
{
    using BillsPaymentSystem.App.Core.Commands.Contracts;
    using BillsPaymentSystem.Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public class DepositCreditCardCommand : ICommandInterface
    {
        private readonly BillsPaymentSystemContext context;

        public DepositCreditCardCommand(BillsPaymentSystemContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            int userId = int.Parse(args[0]);
            decimal amount = decimal.Parse(args[1]);
            int creditCardId = int.Parse(args[2]);

            var user = UserFinder.FindUser(userId, context);


            if (user == null)
            {
                throw new ArgumentException(null, "No such user in the database!");
            }

            var creditCard = user
                .PaymentMethods
                .Select(x => x.CreditCard)
                .FirstOrDefault(x => x.CreditCardId == creditCardId);

            if (creditCard == null)
            {
                throw new ArgumentException(null, "Credit card does not exist!");
            }

            creditCard.Deposit(amount);
            this.context.SaveChanges();

            return $"Your credit card deposit transaction was successfull!";
        }
    }
}
