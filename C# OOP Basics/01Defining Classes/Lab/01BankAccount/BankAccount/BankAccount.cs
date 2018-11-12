using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    class BankAccount
    {
        int id;
        decimal balance;

        public int Id
        {
            get { return this.id; }

            set { this.id = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }

            set { this.balance = value; }
        }
    }
}
