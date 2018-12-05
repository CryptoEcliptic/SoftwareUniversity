using _08MilitaryElite.Contracts;
using _08MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public Corps Corps { get; }
       
    }
}
