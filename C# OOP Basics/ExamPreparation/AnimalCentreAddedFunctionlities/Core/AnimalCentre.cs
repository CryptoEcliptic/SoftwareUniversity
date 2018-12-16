using AnimalCentre.Core.Factories;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotel;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private Hotel hotel;
        private AnimalFactory animalFactory;
        private Procedure chipProcedure;
        private Procedure vaccinationProcedure;
        private Procedure fitnessProcedure;
        private Procedure playProcedure;
        private Procedure dentalProcedure;
        private Procedure nailProcedure;
        private Dictionary<string, List<IAnimal>> proceduresConducted;
        private Dictionary<string, List<IAnimal>> adoptedAnimals;

        public AnimalCentre()
        {
            Setup();
        }

        public void Setup()
        {
            this.hotel = new Hotel();
            this.animalFactory = new AnimalFactory();
            this.chipProcedure = new Chip();
            this.vaccinationProcedure = new Vaccinate();
            this.fitnessProcedure = new Fitness();
            this.playProcedure = new Play();
            this.dentalProcedure = new DentalCare();
            this.nailProcedure = new NailTrim();
            this.proceduresConducted = new Dictionary<string, List<IAnimal>>();
            this.adoptedAnimals = new Dictionary<string, List<IAnimal>>();

            proceduresConducted.Add("Chip", new List<IAnimal>());
            proceduresConducted.Add("Vaccinate", new List<IAnimal>());
            proceduresConducted.Add("Fitness", new List<IAnimal>());
            proceduresConducted.Add("Play", new List<IAnimal>());
            proceduresConducted.Add("DentalCare", new List<IAnimal>());
            proceduresConducted.Add("NailTrim", new List<IAnimal>());
        }

        string result = string.Empty;

        public IReadOnlyDictionary<string, List<IAnimal>> AdoptedAnimals => new Dictionary<string, List<IAnimal>>(adoptedAnimals);

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal = animalFactory.CteateAnimal(type, name, energy, happiness, procedureTime);
            this.hotel.Accommodate(animal);

            result = $"Animal {animal.Name} registered successfully";
            return result;
        }

        public string Chip(string name, int procedureTime)
        {
            IAnimal currentAnimal = GetAnimal(name);
            chipProcedure.DoService(currentAnimal, procedureTime);

            result = $"{currentAnimal.Name} had chip procedure";
            proceduresConducted["Chip"].Add(currentAnimal);
            return result;
        }

        public string Vaccinate(string name, int procedureTime)
        {
            IAnimal currentAnimal = GetAnimal(name);
            vaccinationProcedure.DoService(currentAnimal, procedureTime);

            result = $"{currentAnimal.Name} had vaccination procedure";
            proceduresConducted["Vaccinate"].Add(currentAnimal);
            return result;

        }

        public string Fitness(string name, int procedureTime)
        {
            IAnimal currentAnimal = GetAnimal(name);
            fitnessProcedure.DoService(currentAnimal, procedureTime);
            result = $"{currentAnimal.Name} had fitness procedure";
            proceduresConducted["Fitness"].Add(currentAnimal);
            return result;
        }

        public string Play(string name, int procedureTime)
        {
            IAnimal currentAnimal = GetAnimal(name);
            playProcedure.DoService(currentAnimal, procedureTime);
            proceduresConducted["Play"].Add(currentAnimal);

            result = $"{currentAnimal.Name} was playing for {procedureTime} hours";
            return result;
        }

        public string DentalCare(string name, int procedureTime)
        {
            IAnimal currentAnimal = GetAnimal(name);
            dentalProcedure.DoService(currentAnimal, procedureTime);

            result = $"{currentAnimal.Name} had dental care procedure";
            proceduresConducted["DentalCare"].Add(currentAnimal);
            return result;
        }

        public string NailTrim(string name, int procedureTime)
        {
            IAnimal currentAnimal = GetAnimal(name);
            nailProcedure.DoService(currentAnimal, procedureTime);

            result = $"{currentAnimal.Name} had nail trim procedure";
            proceduresConducted["NailTrim"].Add(currentAnimal);
            return result;
        }

        public string Adopt(string animalName, string owner)
        {
            IAnimal currentAnimal = GetAnimal(animalName);
            hotel.Adopt(animalName, owner);
            
            if (!adoptedAnimals.ContainsKey(owner))
            {
                adoptedAnimals.Add(owner, new List<IAnimal>());
            }
            adoptedAnimals[owner].Add(currentAnimal);

            if (currentAnimal.IsChipped)
            {
                result = $"{owner} adopted animal with chip";
            }
            else if(!currentAnimal.IsChipped)
            {
                result = $"{owner} adopted animal without chip";
            }
            return result;
        }

        public string History(string type)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var procedure in proceduresConducted.Where(x => x.Key == type))
            {
                sb.AppendLine(procedure.Key);
                foreach (var animal in procedure.Value)
                {
                    sb.AppendLine($"    Animal type: {animal.GetType().Name} - {animal.Name} - Happiness: {animal.Happiness} " +
                        $"- Energy: {animal.Energy}");
                }
            }

            result = sb.ToString().TrimEnd();
            return result;
        }

        private IAnimal GetAnimal(string name)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            IAnimal retrunAnimal = hotel.Animals[name];

            return retrunAnimal;
        }
    }
}
