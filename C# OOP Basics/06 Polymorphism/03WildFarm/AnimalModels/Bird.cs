using _03WildFarm.FoodModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03WildFarm.AnimalModels
{
    public abstract class Bird : Animal
    {
        private double wingSize;

        public Bird(string type, string name, double weight, double wingsize)
            : base(type, name, weight)
        {
            this.WingSize = wingsize;
        }

        public double  WingSize
        {
            get { return wingSize; }
            set { wingSize = value; }
        }
        public override string ToString()
        {
            return base.ToString() + $"{this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
