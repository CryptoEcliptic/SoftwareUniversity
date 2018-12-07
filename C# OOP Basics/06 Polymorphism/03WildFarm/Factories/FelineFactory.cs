using _03WildFarm.AnimalModels.Mammals;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03WildFarm.Factories
{
    public class FelineFactory
    {
        public Feline CreateFeline(string type, string name, double weight, string livingRegion, string breed)
        {
            type = type.ToLower();

            switch (type)
            {
                case "cat":
                    return new Cat(type, name, weight, livingRegion, breed);

                case "tiger":
                    return new Tiger(type, name, weight, livingRegion, breed);

                default:
                    return null;
            }
        }
    }
}
