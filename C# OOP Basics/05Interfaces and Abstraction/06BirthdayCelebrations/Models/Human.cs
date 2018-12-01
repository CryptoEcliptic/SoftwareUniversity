using _06BirthdayCelebrations.Contracts;
using System;

namespace _06BirthdayCelebrations.Models
{
    public class Human : IHuman
    {
        private string name;

        private int age;

        private string id;

        private string birthday;

        public Human(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
        }

        public string Name
        {
            get { return name; }
            private set
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
            private set
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
            private set { id = value; }
        }

        public string Birthday
        {
            get { return birthday; }
            private set { birthday = value; }
        }
    }
}
