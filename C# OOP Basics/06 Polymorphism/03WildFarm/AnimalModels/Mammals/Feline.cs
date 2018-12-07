namespace _03WildFarm.AnimalModels.Mammals
{
    public abstract class Feline : Mammal
    {
        private string breed;

        public Feline(string type, string name, double weight, string livingRegion, string breed) 
            : base(type, name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
