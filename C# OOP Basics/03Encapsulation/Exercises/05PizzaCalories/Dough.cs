using System;

namespace _05PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingType;
        private double weight;
        private double calories;

        public Dough(string flourType, string bakingType, double weight)
        {
            this.FlourType = flourType;
            this.BakingType = bakingType;
            this.Weight = weight;
        }

        private double Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    Exception ex = new ArgumentException("Dough weight should be in the range [1..200].");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                weight = value;
            }
        }

        private string BakingType
        {
            get { return bakingType; }
            set
            {
                if (value != "crispy" && value != "chewy" && value != "homemade")
                {
                    Exception ex = new ArgumentException("Invalid type of dough.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                bakingType = value;
            }
        }

        private string FlourType
        {
            get { return flourType; }
            set
            {
                if (value != "white" && value != "wholegrain")
                {
                    Exception ex = new ArgumentException("Invalid type of dough.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                flourType = value;
            }
        }

        private double Calories { get => calories; set => calories = value; }

        internal double CalculateCallories()
        {
            double modifierType = 0;
            double bakingModifier = 0;
            switch (this.flourType)
            {
                case "white":
                    modifierType = 1.5;
                    break;

                case "wholegrain":
                    modifierType = 1.0;
                    break;
                default:
                    break;
            }

            switch (this.bakingType)
            {
                case "crispy":
                    bakingModifier = 0.9;
                    break;

                case "chewy":
                    bakingModifier = 1.1;
                    break;
                case "homemade":
                    bakingModifier = 1.0;
                    break;
                default:
                    break;
            }

            this.Calories = (this.weight * 2) * modifierType * bakingModifier;
            return this.Calories;
       }
    }
}
