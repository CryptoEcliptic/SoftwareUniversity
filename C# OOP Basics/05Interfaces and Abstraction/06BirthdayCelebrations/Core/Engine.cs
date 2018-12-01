using _06BirthdayCelebrations.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06BirthdayCelebrations.Core
{
    public class Engine
    {
        public void Run()
        {
            List<string> allBirthDates = new List<string>();
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                string type = input[0].ToLower();

                switch (type)
                {
                    case "citizen":
                        string nameCitizen = input[1];
                        int ageCitizen = int.Parse(input[2]);
                        string idCitizen = input[3];
                        string birthdateCitizen = input[4];
                        Human citizen = new Human(nameCitizen, ageCitizen, idCitizen, birthdateCitizen);
                        allBirthDates.Add(citizen.Birthday);
                        break;

                    case "pet":
                        string namePet = input[1];
                        string birthdatePet = input[2];

                        Pet pet = new Pet(namePet, birthdatePet);
                        allBirthDates.Add(pet.Birthdate);
                        break;

                    case "robot":
                       
                        break;

                    default:
                        break;
                }

                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            string yearToFind = Console.ReadLine();


            allBirthDates = allBirthDates.FindAll(x => x.EndsWith(yearToFind));
            
            foreach (var id in allBirthDates)
            {
                Console.WriteLine(id);
            }
        }
    }
}
