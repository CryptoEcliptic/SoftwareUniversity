using _03WildFarm.Contracts;

namespace _03WildFarm.FoodModels
{
    public class Food : IFood
    {
        private int quantity;

        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

    }
}
