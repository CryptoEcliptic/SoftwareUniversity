using AnimalCentre.Core.IO;
using AnimalCentre.Core.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AnimalCentre.Core
{
    public class Engine
    {
        private IReader reader;
        private IWriter writer;
        private AnimalCentre animalCentre;
        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.animalCentre = new AnimalCentre();
        }
        public void Run()
        {

            string input = reader.ReadLine();
            string result = string.Empty;

            while (input != "End")
            {
                string[] arguments = input.Split();

                string command = arguments[0];
                try
                {
                    switch (command)
                    {

                        case "RegisterAnimal":
                            string type = arguments[1];
                            string name = arguments[2];
                            int energy = int.Parse(arguments[3]);
                            int happiness = int.Parse(arguments[4]);
                            int procedureTime = int.Parse(arguments[5]);

                            result = animalCentre.RegisterAnimal(type, name, energy, happiness, procedureTime);
                            break;

                        case "Chip":
                            string animalName = arguments[1];
                            int chipProcedureTime = int.Parse(arguments[2]);

                            result = animalCentre.Chip(animalName, chipProcedureTime);
                            break;

                        case "Vaccinate":
                            string vaccinateAnimalName = arguments[1];
                            int vaccinateProcedureTime = int.Parse(arguments[2]);

                            result = animalCentre.Vaccinate(vaccinateAnimalName, vaccinateProcedureTime);
                            break;

                        case "Fitness":
                            string fitnessAnimalName = arguments[1];
                            int fitnessProcedureTime = int.Parse(arguments[2]);

                            result = animalCentre.Fitness(fitnessAnimalName, fitnessProcedureTime);
                            break;

                        case "Play":
                            string platAnimalName = arguments[1];
                            int playProcedureTime = int.Parse(arguments[2]);

                            result = animalCentre.Play(platAnimalName, playProcedureTime);
                            break;

                        case "DentalCare":
                            string dentalAnimalName = arguments[1];
                            int dentalProcedureTime = int.Parse(arguments[2]);

                            result = animalCentre.DentalCare(dentalAnimalName, dentalProcedureTime);
                            break;

                        case "NailTrim":
                            string nailAnimalName = arguments[1];
                            int nailProcedureTime = int.Parse(arguments[2]);

                            result = animalCentre.NailTrim(nailAnimalName, nailProcedureTime);
                            break;

                        case "Adopt":
                            string animalToAdopt = arguments[1];
                            string ownerName = arguments[2];

                            result = animalCentre.Adopt(animalToAdopt, ownerName);
                            break;

                        case "History":
                            string procedureType = arguments[1];

                            result = animalCentre.History(procedureType);
                            break;
                        default:
                            break;
                    }
                }
                catch (InvalidOperationException ae)
                {

                    result = "InvalidOperationException: " + ae.Message;
                }
                catch (ArgumentException ae)
                {
                    result = "ArgumentException: " + ae.Message;
                }

                writer.WriteLine(result);
                
                input = reader.ReadLine();
            }
            StringBuilder sb = new StringBuilder();
            foreach (var owner in animalCentre.AdoptedAnimals.OrderBy(x =>x.Key))
            {
                sb.AppendLine($"--Owner: {owner.Key}");
                sb.Append("    - Adopted animals: ");
                
                foreach (var animal in owner.Value)
                {
                    sb.Append(animal.Name + " ");
                }
                sb.AppendLine();
            }

            result = sb.ToString().TrimEnd();
            writer.WriteLine(result);
        }
    }
}
