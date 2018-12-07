using _03WildFarm.FoodModels;
using System;

namespace _03WildFarm.AnimalModels.Birds
{
    public class Hen : Bird
    {
        private const double henWeightIndex = 0.35;

        public Hen(string type, string name, double weight, double wingsize) 
            : base(type, name, weight, wingsize)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }
        
        public override void Eat(Food food)
        {
            this.FoodEaten += food.Quantity;
            this.Weight += this.FoodEaten * henWeightIndex;
        }
    }
}
