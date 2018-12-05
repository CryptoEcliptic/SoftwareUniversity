using _08MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<IPrivate>();
        }

        public ICollection<IPrivate> Privates
        {
            get;
            set;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nPrivates: {(this.Privates.Count == 0 ? "" : "\n ")}{string.Join("\n ", this.Privates)}";
        }
    }
}
