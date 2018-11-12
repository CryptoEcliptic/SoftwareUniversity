using System;
using System.Collections.Generic;

namespace BankAccount
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = commands[0];
                int identifier = int.Parse(commands[1]);
                switch (action)
                {
                    case "Create":
                        Create(identifier, accounts);
                        break;

                    case "Deposit":
                        decimal amount = decimal.Parse(commands[2]);
                        Deposit(identifier, amount, accounts);
                        break;

                    case "Withdraw":
                        amount = decimal.Parse(commands[2]);
                        Withdraw(identifier, amount, accounts);
                        break;

                    case "Print":
                        if (!accounts.ContainsKey(identifier))
                        {
                            Console.WriteLine("Account does not exist");
                        }
                        else
                        {
                            foreach (var account in accounts)
                            {
                                if (account.Key == identifier)
                                {
                                    Console.WriteLine($"Account ID{account.Key}, balance {account.Value.Balance:f2}");
                                }
                            }
                        }
                        
                        break;

                    default:
                        break;
                }
                input = Console.ReadLine();
            }
        }
        private static void Create(int id, Dictionary<int, BankAccount> account)
        {
            if (account.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                BankAccount acc = new BankAccount();
                acc.Id = id;
                account.Add(id, acc);
            }
        }
        private static void Deposit(int id, decimal amount, Dictionary<int, BankAccount> account)
        {
            if (!account.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else if (account.ContainsKey(id))
            {
                account[id].Deposit(amount);
            }
        }
        private static void Withdraw(int id, decimal amount, Dictionary<int, BankAccount> account)
        {
            if (!account.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else if (account.ContainsKey(id))
            {
                
                decimal balance = account[id].Balance;
                if (balance < amount)
                {
                    Console.WriteLine("Insufficient balance");
                }
                else
                {
                    account[id].Withdraw(amount);
                    
                }
                
            }
        }
    }
}
