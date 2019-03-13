namespace BillsPaymentSystem.Models
{
    using BillsPaymentSystem.Models.Attributes;
    using BillsPaymentSystem.Models.Enums;

    public class PaymentMethod
    {
        public PaymentMethod()
        {

        }

        public PaymentMethod(PaymentMethodType type, User user, BankAccount bankAccount)
        {
            this.Type = type;
            this.User = user;
            this.BankAccount = bankAccount;
        }

        public PaymentMethod(PaymentMethodType type, User user, CreditCard creditCard)
        {
            this.Type = type;
            this.User = user;
            this.CreditCard = creditCard;
        }

        public int Id { get; set; }

        public PaymentMethodType Type { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        [Xor(nameof(CreditCardId))]
        public int? BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }

        public int? CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}
