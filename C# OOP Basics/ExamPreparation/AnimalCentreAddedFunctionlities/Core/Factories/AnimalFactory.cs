using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace AnimalCentre.Core.Factories
{
    public class AnimalFactory
    {
        public IAnimal CteateAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal newAnimal = null;
            switch (type)
            {
                case "Lion":
                    newAnimal = new Lion(name, energy, happiness, procedureTime);
                    break;
                case "Dog":
                    newAnimal = new Dog(name, energy, happiness, procedureTime);
                    break;
                case "Pig":
                    newAnimal = new Pig(name, energy, happiness, procedureTime);
                    break;
                case "Cat":
                    newAnimal = new Cat(name, energy, happiness, procedureTime);
                    break;

                default:
                    break;
            }

            return newAnimal;
        }
    }
}
