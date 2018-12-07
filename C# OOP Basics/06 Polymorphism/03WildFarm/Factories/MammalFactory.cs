using _03WildFarm.AnimalModels;
using _03WildFarm.AnimalModels.Mammals;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03WildFarm.Factories
{
    public class MammalFactory
    {
        public Mammal CreateMammal(string type, string name, double weight, string livingRegion)
        {
            type = type.ToLower();
            switch (type)
            {
                case "mouse":
                    return new Mouse(type, name, weight, livingRegion);

                case "dog":
                    return new Dog(type, name, weight, livingRegion);

                default:
                    return null;
            }
        }
    }
}
