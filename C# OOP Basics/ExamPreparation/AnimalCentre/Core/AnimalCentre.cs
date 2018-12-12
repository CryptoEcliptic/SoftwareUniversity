using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotel;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private Hotel hotel;
        private Procedure chipProcedure;
        private Procedure vaccination;
        private Procedure fitness;
        private Procedure dentalCare;
        private Procedure play;
        private Procedure nailTrim;
        private Dictionary<string, List<IAnimal>> procedures;
        private Dictionary<string, List<IAnimal>> adoptedAnimals;
        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.chipProcedure = new Chip();
            this.vaccination = new Vaccinate();
            this.fitness = new Fitness();
            this.play = new Play();
            this.dentalCare = new DentalCare();
            this.nailTrim = new NailTrim();
            this.procedures = new Dictionary<string, List<IAnimal>>();
            this.adoptedAnimals = new Dictionary<string, List<IAnimal>>();
        }

        private string result = string.Empty;
        IAnimal currentAnimal;

        public IReadOnlyDictionary<string, List<IAnimal>> AdoptedAnimals => 
            new ReadOnlyDictionary<string, List<IAnimal>>(this.adoptedAnimals);

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            switch (type)
            {
                case "Cat":
                    currentAnimal = new Cat(name, energy, happiness, procedureTime);
                    break;

                case "Dog":
                    currentAnimal = new Dog(name, energy, happiness, procedureTime);
                    break;

                case "Lion":
                    currentAnimal = new Lion(name, energy, happiness, procedureTime);
                    break;

                case "Pig":
                    currentAnimal = new Pig(name, energy, happiness, procedureTime);
                    break;

                default:
                    break;
            }

            this.hotel.Accommodate(currentAnimal);

            result = $"Animal {currentAnimal.Name} registered successfully";
            return result;
        }

        public string Chip(string name, int procedureTime)
        {
            IAnimal animal = GetAnimal(name);
            chipProcedure.DoService(animal, procedureTime);
           
            if (!procedures.ContainsKey("Chip"))
            {
                procedures.Add("Chip", new List<IAnimal>());
                procedures["Chip"].Add(animal);
            }
            else
            {
                procedures["Chip"].Add(animal);
            }
     
            result = $"{name} had chip procedure";
            return result;
        }

        public string Vaccinate(string name, int procedureTime)
        {
            IAnimal animal = GetAnimal(name);
            vaccination.DoService(animal, procedureTime);
            if (!procedures.ContainsKey("Vaccinate"))
            {
                procedures.Add("Vaccinate", new List<IAnimal>());
                procedures["Vaccinate"].Add(animal);
            }
            else
            {
                procedures["Vaccinate"].Add(animal);
            }
            result = $"{name} had vaccination procedure";
            return result;
        }

        public string Fitness(string name, int procedureTime)
        {
            IAnimal animal = GetAnimal(name);
            fitness.DoService(animal, procedureTime);
            if (!procedures.ContainsKey("Fitness"))
            {
                procedures.Add("Fitness", new List<IAnimal>());
                procedures["Fitness"].Add(animal);
            }
            else
            {
                procedures["Fitness"].Add(animal);
            }
            result = $"{name} had fitness procedure";
            return result;
        }

        public string Play(string name, int procedureTime)
        {
            IAnimal animal = GetAnimal(name);
            play.DoService(animal, procedureTime);
            if (!procedures.ContainsKey("Play"))
            {
                procedures.Add("Play", new List<IAnimal>());
                procedures["Play"].Add(animal);
            }
            else
            {
                procedures["Play"].Add(animal);
            }

            result = $"{name} was playing for {procedureTime} hours";
            return result;
        }

        public string DentalCare(string name, int procedureTime)
        {
            IAnimal animal = GetAnimal(name);
            dentalCare.DoService(animal, procedureTime);
            if (!procedures.ContainsKey("DentalCare"))
            {
                procedures.Add("DentalCare", new List<IAnimal>());
                procedures["DentalCare"].Add(animal);
            }
            else
            {
                procedures["DentalCare"].Add(animal);
            }
            result = $"{name} had dental care procedure";
            return result;
        }

        public string NailTrim(string name, int procedureTime)
        {
            IAnimal animal = GetAnimal(name);
            nailTrim.DoService(animal, procedureTime);
            if (!procedures.ContainsKey("NailTrim"))
            {
                procedures.Add("NailTrim", new List<IAnimal>());
                procedures["NailTrim"].Add(animal);
            }
            else
            {
                procedures["NailTrim"].Add(animal);
            }
            result = $"{name} had nail trim procedure";
            return result;
        }

        public string Adopt(string animalName, string owner)
        {
            IAnimal animal = GetAnimal(animalName);
            hotel.Adopt(animalName, owner);

            if (animal.IsChipped)
            {
                result = $"{owner} adopted animal with chip";
            }
            else if (!animal.IsChipped)
            {
                result = $"{owner} adopted animal without chip";
            }
            if (!adoptedAnimals.ContainsKey(owner))
            {
                adoptedAnimals.Add(owner, new List<IAnimal>());
            }
            adoptedAnimals[owner].Add(animal);
            return result;
        }

        public string History(string type)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(type);
            foreach (var procedure in procedures)
            {
                if (procedure.Key == type)
                {
                    foreach (var animal in procedure.Value)
                    {
                        sb.AppendLine($"    Animal type: {animal.GetType().Name} - {animal.Name} - Happiness: {animal.Happiness} " +
                            $"- Energy: {animal.Energy}");
                    }
                }

            }

            return sb.ToString().TrimEnd();
        }

        private IAnimal GetAnimal(string name)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            IAnimal animal = hotel.Animals[name];
            return animal;
        }
    }
}
