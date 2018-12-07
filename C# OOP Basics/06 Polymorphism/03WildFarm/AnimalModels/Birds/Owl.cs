using _03WildFarm.FoodModels;
using System;

namespace _03WildFarm.AnimalModels.Birds
{
    public class Owl : Bird
    {
        private const double owlWeightIndex = 0.25;

        public Owl(string type, string name, double weight, double wingsize) 
            : base(type, name, weight, wingsize)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                this.FoodEaten += food.Quantity;
                this.Weight += this.FoodEaten * owlWeightIndex;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            
        }
    }
}
