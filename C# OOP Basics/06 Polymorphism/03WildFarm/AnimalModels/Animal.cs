using _03WildFarm.Contracts;
using _03WildFarm.FoodModels;

namespace _03WildFarm.AnimalModels
{
    public class Animal : IAnimal
    {
        private string name;

        private double weight;

        private int foodEaten;

        private string type;

        public Animal(string type, string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.Type = type;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public int FoodEaten
        {
            get { return foodEaten; }
            set { foodEaten = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public virtual void ProduceSound()
        {
        }

        public virtual void Eat(Food food)
        {
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }

    }
}
