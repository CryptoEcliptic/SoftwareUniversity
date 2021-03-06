﻿namespace BillsPaymentSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BankAccount
    {
        public BankAccount()
        {

        }

        public BankAccount(decimal balance, string bankName, string swift)
        {
            this.Balance = balance;
            this.BankName = bankName;
            this.SWIFT = swift;
        }
        
        public int BankAccountId { get; set; }

        [Range(typeof(decimal), "0.01", "10000000000")]
        public decimal Balance { get; set; }

        [Required]
        [MinLength(3), MaxLength(50)]
        public string BankName { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string SWIFT { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public void Withdraw(decimal amount)
        {

            if (amount <= 0)
            {
                throw new ArgumentException(null, "Invalid withdraw amount!");
            }

            if (this.Balance - amount < 0)
            {
                throw new ArgumentException(null, "Insufficient funds!");
            }

            this.Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(null, "Invalid deposit amount!");
            }
            this.Balance += amount;
        }
    }
}
