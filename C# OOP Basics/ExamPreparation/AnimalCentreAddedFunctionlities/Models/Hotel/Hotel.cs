using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Hotel
{
    public class Hotel : IHotel
    {
        private const int capacityConst = 10;

        private int capacity;
        private Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
            this.Capacity = capacityConst;
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }
            private set
            {
                capacity = value;
            }
        }

        public IReadOnlyDictionary<string, IAnimal> Animals => new Dictionary<string, IAnimal>(animals);

        public void Accommodate(IAnimal animal)
        {
            if (animals.Count >= this.capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }
            if (animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }
            animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (!animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
            IAnimal currentAnimal = animals[animalName];
            currentAnimal.IsAdopt = true;
            currentAnimal.Owner = owner;
            animals.Remove(animalName);
        }
    }
}
