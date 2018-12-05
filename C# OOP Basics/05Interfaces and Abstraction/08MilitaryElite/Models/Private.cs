using _08MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        private decimal salary;

        public Private(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public override string ToString()
        {
            return base.ToString() + $" Salary: {this.Salary:f2}";
        }
    }
}
