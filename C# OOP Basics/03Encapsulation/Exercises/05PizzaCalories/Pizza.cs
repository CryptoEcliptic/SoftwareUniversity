using System;
using System.Collections.Generic;
using System.Text;

namespace _05PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private Topping topping;
        private List<Topping> toppings;
        private double calories;

        public Pizza(string name)
        {
            this.Name = name;
            this.Toppings = new List<Topping>();
        }
        public Pizza(string name, Dough dough) : this(name)
        {
            this.Dough = dough;
        }
        public Pizza(string name, Dough dough, Topping topping) : this(name, dough)
        {
            this.Topping = topping;
        }

        public Topping Topping
        {
            get { return topping; }
            set { topping = value; }
        }

        public double Calories
        {
            get { return calories; }
            set { calories = value; }
        }

        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 1 || value.Length > 15)
                {
                    Exception ae = new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                    Console.WriteLine(ae.Message);
                    Environment.Exit(0);
                }
                name = value;
            }
        }

        public List<Topping> Toppings
        {
           get {return toppings; }
           set
           {
                toppings = value;
           }
        }

        //public void CalculateCallories()
        //{
        //    this.Calories += this.Dough.Calories + this.Topping.Calories;
        //}

        public void AddToppings(Topping topping)
        {
            if (Toppings.Count > 10)
            {
                Exception ae = new ArgumentException("Number of toppings should be in range [0..10].");
                Console.WriteLine(ae.Message);
                Environment.Exit(0);
            }
            Toppings.Add(topping);
        }

    }
}
