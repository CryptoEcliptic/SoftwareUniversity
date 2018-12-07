using _03WildFarm.AnimalModels;
using _03WildFarm.AnimalModels.Birds;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03WildFarm.Factories
{
    public class BirdFactory
    {
        public Bird CreateBird(string type, string name, double weight, double wingSize)
        {
            type = type.ToLower();
            switch (type)
            {
                case "hen":
                    return new Hen(type, name, weight, wingSize);

                case "owl":
                    return new Owl(type, name, weight, wingSize);

                default:
                    return null;
            }
        }
    }
}
