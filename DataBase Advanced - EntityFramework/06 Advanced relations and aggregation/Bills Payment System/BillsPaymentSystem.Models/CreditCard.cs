﻿namespace BillsPaymentSystem.Models
{
    using BillsPaymentSystem.Models.Attributes;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreditCard
    {
        public CreditCard()
        {

        }

        public CreditCard(decimal limit, decimal moneyOwed, DateTime expitarionDate)
        {
            this.Limit = limit;
            this.MoneyOwed = moneyOwed;
            this.ExpirationDate = expitarionDate;
        }

        
        public int CreditCardId { get; set; }

        [Range(typeof(decimal), "0.01", "10000000000")]
        public decimal Limit { get; set; }

        [Range(typeof(decimal), "0.01", "10000000000")]
        public decimal MoneyOwed { get; set; }

        public decimal LimitLeft => this.Limit - this.MoneyOwed;
        
        [ExpirationDate]
        public DateTime ExpirationDate { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(null, "Invalid withdraw amount!");
            }

            if (this.MoneyOwed - amount < 0)
            {
                throw new ArgumentException(null, "Insufficient funds!");
            }

            this.MoneyOwed -= amount;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(null, "Invalid deposit amount!");
            }
            this.MoneyOwed += amount;
        }
    }
}
