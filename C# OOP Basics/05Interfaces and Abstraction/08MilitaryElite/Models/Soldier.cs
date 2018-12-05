using _08MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08MilitaryElite.Models
{
    public abstract class Soldier : ISoldier
    {
        private string id;
        private string firstName;
        private string lastName;

        public Soldier(string id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
 
        public string  FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public override string ToString()
        {
            return $" Name: {this.FirstName} {this.LastName} Id: {this.Id}";
        }

    }
}
