using System;

namespace _05PizzaCalories
{
    public class Topping
    {
        private string type;
        private double weight;
        private double calories;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        private double Calories
        {
            get { return calories; }
            set { calories = value; }
        }

        private double Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    string capital = this.Type.Substring(0, 1).ToUpper();
                    var message = capital + this.Type.ToString().Remove(0, 1);
                    Exception ae = new ArgumentException($"{message} weight should be in the range [1..50].");
                    Console.WriteLine(ae.Message);
                    Environment.Exit(0);
                }
                weight = value;
            } 
        }

        private string Type
        {
            get { return type; }
            set
            {
                if (value != "meat" && value != "veggies" && value != "cheese" && value != "sauce")
                {
                    
                    string capital = value.Substring(0, 1).ToUpper();
                    var message = capital + value.ToString().Remove(0, 1);
                    Exception ae = new ArgumentException($"Cannot place {message} on top of your pizza.");
                    Console.WriteLine(ae.Message);
                    Environment.Exit(0);
                }
                type = value;
            }
        }
        internal double CalculateCalories()
        {
            double modifier = 0;
            switch (this.type)
            {
                case "meat":
                    modifier = 1.2;
                    break;

                case "veggies":
                    modifier = 0.8;
                    break;
                case "cheese":
                    modifier = 1.1;
                    break;
                case "sauce":
                    modifier = 0.9;
                    break;
                default:
                    break;
            }
            this.Calories = (this.Weight * 2) * modifier;
            return this.Calories;
        }
    }
}
