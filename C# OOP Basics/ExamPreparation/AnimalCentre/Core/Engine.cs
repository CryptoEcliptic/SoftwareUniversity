using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AnimalCentre.Core
{
    public class Engine
    {
        private AnimalCentre animalCentre;
       
        public Engine()
        {
            this.animalCentre = new AnimalCentre();
        }

        public object AdoptedAnimals { get; private set; }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] arguments = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = arguments[0];
                string output = string.Empty;
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
                            output = animalCentre.RegisterAnimal(type, name, energy, happiness, procedureTime);
                            break;

                        case "Chip":
                            string animalName = arguments[1];
                            int timeForProcedure = int.Parse(arguments[2]);
                            output = animalCentre.Chip(animalName, timeForProcedure);
                            break;

                        case "Vaccinate":
                            animalName = arguments[1];
                            timeForProcedure = int.Parse(arguments[2]);
                            output = animalCentre.Vaccinate(animalName, timeForProcedure);
                            break;

                        case "Fitness":
                            animalName = arguments[1];
                            timeForProcedure = int.Parse(arguments[2]);
                            output = animalCentre.Fitness(animalName, timeForProcedure);
                            break;

                        case "Play":
                            animalName = arguments[1];
                            timeForProcedure = int.Parse(arguments[2]);
                            output = animalCentre.Play(animalName, timeForProcedure);
                            break;

                        case "DentalCare":
                            animalName = arguments[1];
                            timeForProcedure = int.Parse(arguments[2]);
                            output = animalCentre.DentalCare(animalName, timeForProcedure);
                            break;

                        case "NailTrim":
                            animalName = arguments[1];
                            timeForProcedure = int.Parse(arguments[2]);
                            output = animalCentre.NailTrim(animalName, timeForProcedure);
                            break;

                        case "Adopt":
                            animalName = arguments[1];
                            string owner = arguments[2];
                            output = animalCentre.Adopt(animalName, owner);
                            break;

                        case "History":
                            string procedureType = arguments[1];
                            output = animalCentre.History(procedureType);
                            break;

                        default:
                            break;
                    }

                    Console.WriteLine(output);
                }
                catch (InvalidOperationException oe)
                {
                    Console.WriteLine("InvalidOperationException: " + oe.Message);
                }
                catch (ArgumentException oe)
                {
                    Console.WriteLine("ArgumentException: " + oe.Message);
                }

                input = Console.ReadLine();
            }

            var adoptedAnimalsCollestion = this.animalCentre.AdoptedAnimals;
            StringBuilder sb = new StringBuilder();
            foreach (var owner in adoptedAnimalsCollestion.OrderBy(x => x.Key))
            {
                sb.AppendLine($"--Owner: {owner.Key}");
                sb.Append($"    - Adopted animals: ");
                foreach (var item in owner.Value)
                {
                    sb.Append(item.Name + " ");
                }
                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
