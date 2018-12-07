using _03WildFarm.FoodModels;
using System;

namespace _03WildFarm.AnimalModels.Mammals
{
    public class Mouse : Mammal
    {
        private const double mouseWeightIndex = 0.10;

        public Mouse(string type, string name, double weight, string livingRegion) 
            : base(type, name, weight, livingRegion)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Squeak");
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Fruit)
            {

                this.FoodEaten += food.Quantity;
                this.Weight += this.FoodEaten * mouseWeightIndex;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            
        }
        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
