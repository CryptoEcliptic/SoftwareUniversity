using _03WildFarm.FoodModels;
using System;

namespace _03WildFarm.AnimalModels.Mammals
{
    public class Dog : Mammal
    {
        private const double dogWeightIndex = 0.40;

        public Dog(string type, string name, double weight, string livingRegion) 
            : base(type, name, weight, livingRegion)
        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                this.FoodEaten += food.Quantity;
                this.Weight += this.FoodEaten * dogWeightIndex;
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
