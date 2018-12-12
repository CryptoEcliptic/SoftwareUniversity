using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AnimalCentre.Models.Hotel
{
    public class Hotel : IHotel
    {
        private Dictionary<string, IAnimal> animals;
        private int capacity;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
            this.Capacity = 10;
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public IReadOnlyDictionary<string, IAnimal> Animals => new ReadOnlyDictionary<string, IAnimal>(this.animals);
        

        public void Accommodate(IAnimal animal)
        {
            if (this.animals.Count >= this.Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }
            if (animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }
            this.animals.Add(animal.Name, animal);
            
        }

        public void Adopt(string animalName, string owner)
        {
            if (!this.animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
            IAnimal currentAnimal = animals[animalName];
            currentAnimal.Owner = owner;
            currentAnimal.IsAdopt = true;
            animals.Remove(animalName);
        }
    }
}
