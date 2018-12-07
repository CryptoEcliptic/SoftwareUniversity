using _03WildFarm.FoodModels;
using System;

namespace _03WildFarm.AnimalModels.Mammals
{
    public class Tiger : Feline
    {
        private const double tigerWeightIndex = 1.00;

        public Tiger(string type, string name, double weight, string livingRegion, string breed) 
            : base(type, name, weight, livingRegion, breed)
        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("ROAR!!!");
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                this.FoodEaten += food.Quantity;
                this.Weight += this.FoodEaten * tigerWeightIndex;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
           
        }
    }
}
