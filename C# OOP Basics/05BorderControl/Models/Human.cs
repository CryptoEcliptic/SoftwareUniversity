using _05BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05BorderControl.Models
{
    public class Human : IHuman
    {
        private string name;
        private int age;
        private string id;

        public Human(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new FormatException("The name cannot be null or empty");
                }
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 0)
                {
                    throw new FormatException("The age cannot be zero or negative");
                }
                age = value;
            }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }


    }
}
