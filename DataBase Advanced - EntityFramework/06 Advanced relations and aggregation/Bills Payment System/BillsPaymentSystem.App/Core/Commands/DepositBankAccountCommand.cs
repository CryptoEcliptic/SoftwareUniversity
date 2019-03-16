namespace BillsPaymentSystem.App.Core.Commands
{
    using BillsPaymentSystem.App.Core.Commands.Contracts;
    using BillsPaymentSystem.Data;
    using System;
    using System.Linq;

    public class DepositBankAccountCommand : ICommandInterface
    {
        private readonly BillsPaymentSystemContext context;

        public DepositBankAccountCommand(BillsPaymentSystemContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            int userId = int.Parse(args[0]);
            decimal amount = decimal.Parse(args[1]);
            int bankAccountId = int.Parse(args[2]);

            var user = UserFinder.FindUser(userId, context);

            var bankAccount = user
                .PaymentMethods
                .Select(x => x.BankAccount)
                .FirstOrDefault(x => x.BankAccountId == bankAccountId);

            if (bankAccount == null)
            {
                throw new ArgumentException(null, "Bank account does not exist!");
            }

            bankAccount.Deposit(amount);
            this.context.SaveChanges();

            return $"Your bank account deposit transaction was successfull!";
        }
    }
}
