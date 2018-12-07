using _03WildFarm.FoodModels;
using System;

namespace _03WildFarm.AnimalModels.Mammals
{
    public class Cat : Feline
    {
        private const double catWeightIndex = 0.30;

        public Cat(string type, string name, double weight, string livingRegion, string breed) 
            : base(type, name, weight, livingRegion, breed)
        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Meat)
            {
                this.FoodEaten += food.Quantity;
                this.Weight += this.FoodEaten * catWeightIndex;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
