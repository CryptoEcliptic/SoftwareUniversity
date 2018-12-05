using _07FoodShortage.Contracts;
using System;

namespace _07FoodShortage.Models
{
    public class Human : IHuman, IBuyer
    {
        private string name;

        private int age;

        private string id;

        private string birthday;

        private int food;

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
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            private set
            {
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

        public int Food
        {
            get { return food; }
            set { food = 0; }
        }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
