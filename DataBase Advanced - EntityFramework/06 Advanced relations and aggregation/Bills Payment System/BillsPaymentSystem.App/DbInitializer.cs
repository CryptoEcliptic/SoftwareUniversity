namespace BillsPaymentSystem.App
{
    using BillsPaymentSystem.Data;
    using BillsPaymentSystem.Models;
    using BillsPaymentSystem.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class DbInitializer
    {  
        public static void Seed(BillsPaymentSystemContext context)
        {
            using (context)
            {
                context.Database.EnsureDeleted();

                context.Database.EnsureCreated();

                SeedUsers(context);
                SeedCreditCards(context);
                SeedBankAccounts(context);
                SeedPaymentMethods(context);
            }  
        }

        private static void SeedPaymentMethods(BillsPaymentSystemContext context)
        {
            var bankAccounts = context.BankAccounts.ToArray();
            var creditCards = context.CreditCards.ToArray();
            var users = context.Users.ToArray();
            List<PaymentMethod> paymentMethods = new List<PaymentMethod>();

            for (int i = 0; i < users.Length; i++)
            {
                var user = users[i];
                if (i % 2 == 0)
                {
                    var bankAccount = bankAccounts[i];
                    var type = PaymentMethodType.BankAccount;
                    var paymentMethod = new PaymentMethod(type, user, bankAccount);

                    if (!IsValid(paymentMethod))
                    {
                        continue;
                    }

                    paymentMethods.Add(paymentMethod);
                }
                else if (i % 2 == 1)
                {
                    var creditCard = creditCards[i];
                    var type = PaymentMethodType.CreditCard;
                    var paymentMethod = new PaymentMethod(type, user, creditCard);

                    if (!IsValid(paymentMethod))
                    {
                        continue;
                    }

                    paymentMethods.Add(paymentMethod);
                }

            }

            context.PaymentMethods.AddRange(paymentMethods);
            context.SaveChanges();
        }

        private static void SeedBankAccounts(BillsPaymentSystemContext context)
        {
            var bankAccounts = new List<BankAccount>
            {
                new BankAccount(1100.00m, "United Blgarian Bank", "UBBSBGSF"),
                new BankAccount(1200.00m, "United Blgarian Bank", "UBBSBGSF"),
                new BankAccount(1500.00m, "United Blgarian Bank", "UBBSBGSF"),
                new BankAccount(1500.00m, "Raiffeisenbank (Bulgaria)", "RZBBBGSF"),
                new BankAccount(100.00m, "Raiffeisenbank (Bulgaria)", "RZBBBGSF"),
                new BankAccount(500.00m, "Юробанк България АД", "BPBIBGSF"),
                new BankAccount(850.00m, "Юробанк България АД", "BPBIBGSF"),
                new BankAccount(7555.00m, "Юробанк България АД", "BPBIBGSF"),
                new BankAccount(999.00m, "DSK Bank", "STSABGSF"),
                new BankAccount(00.00m, "DSK Bank", "STSABGSF") //Invalid Balance
            };

            List<BankAccount> validAccounts = new List<BankAccount>();

            for (int i = 0; i < bankAccounts.Count; i++)
            {
                if (!IsValid(bankAccounts[i]))
                {
                    continue;
                }
                validAccounts.Add(bankAccounts[i]);
            }

            context.BankAccounts.AddRange(validAccounts);
            context.SaveChanges();
        }

        private static void SeedCreditCards(BillsPaymentSystemContext context)
        {
            List<CreditCard> creditCards = new List<CreditCard>
            {
                new CreditCard(1500.00m, 500.00m, new DateTime(2020,01,01)),
                new CreditCard(2500.00m, 750.00m, new DateTime(2021,01,01)),
                new CreditCard(1500.00m, 800.00m, new DateTime(2022,01,01)),
                new CreditCard(3500.00m, 3000.00m, new DateTime(2023,01,01)),
                new CreditCard(2000.00m, 500.00m, new DateTime(2024,01,01)),
                new CreditCard(1800.00m, 500.00m, new DateTime(2025,01,01)),
                new CreditCard(3000.00m, 1000.00m, new DateTime(2026,01,01)),
                new CreditCard(3500.00m, 1000.00m, new DateTime(2027,01,01)),
                new CreditCard(5000.00m, 1000.00m, new DateTime(2028,01,01)),
                new CreditCard(0.00m, 1000.00m, new DateTime(2028,01,01)), // Invalid Limit
                new CreditCard(30000.00m, 1000.00m, new DateTime(2005,01,01)) //Invalid Expiration Date
            };

            List<CreditCard> validCreditCards = new List<CreditCard>();

            for (int i = 0; i < creditCards.Count; i++)
            {
                if (!IsValid(creditCards[i]))
                {
                    continue;
                }
                validCreditCards.Add(creditCards[i]);
            }

            context.CreditCards.AddRange(validCreditCards);
            context.SaveChanges();

        }

        private static void SeedUsers(BillsPaymentSystemContext context)
        {
            List<User> users = new List<User>
            {
                new User("Pesho", "Peshov", "pesho2000@abv.bg", "qwerty"),
                new User("Gosho", "Goshev", "gosho@abv.bg", "12345"),
                new User("Sasho", "Sashov", "sasho@abv.bg", "qwerty"),
                new User("Simona", "Simeonova", "moni@abv.bg", "12345"),
                new User("Eli", "Stoykova", "eli@abv.bg", "qwerty"),
                new User("Spiridon", "Spirov", "spiro@abv.bg", "rakia"),
                new User("Nora", "Marinova", "nora@abv.bg", "wine"),
                new User("Maya", "Blazheva", "maya@abv.bg", "dance"),
                new User("Diliana", "Koeva", "didi@gmail.com", "123456"),
                new User("ERROR", "ERROR", "", "123456"), //invalidEmail
                new User("", "ERROR", "error@mail.bg", "123456"), //invalidFirstName
            };

            List<User> validUsers = new List<User>();
            for (int i = 0; i < users.Count; i++)
            {
                if (!IsValid(users[i]))
                {
                    continue;
                }
                validUsers.Add(users[i]);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            List<ValidationResult> validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }
    }
}
