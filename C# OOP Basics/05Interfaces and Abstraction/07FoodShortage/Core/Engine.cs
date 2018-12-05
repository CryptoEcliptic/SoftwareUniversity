using _07FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _06BirthdayCelebrations.Core
{
    public class Engine
    {
        public void Run()
        {
            List<Human> humans = new List<Human>();
            List<Rebel> rebels = new List<Rebel>();

            int numberInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberInputs; i++)
            {
                string[] infoArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (infoArgs.Length == 4)
                {
                    string namePerson = infoArgs[0];
                    int agePerson = int.Parse(infoArgs[1]);
                    string idPerson = infoArgs[2];
                    string birthdatePerson = infoArgs[3];
                    humans.Add(new Human(namePerson, agePerson, idPerson, birthdatePerson));
                }
                else if (infoArgs.Length == 3)
                {
                    string nameRebel = infoArgs[0];
                    int ageRebel = int.Parse(infoArgs[1]);
                    string group = infoArgs[2];
                    rebels.Add(new Rebel(nameRebel, ageRebel, group));
                }
            }

            string buyerName = Console.ReadLine();
            int totalFood = 0;
            while (buyerName != "End")
            {
                bool hasThatHumanInTheList = humans.Any(x => x.Name == buyerName);
                bool hasThatRebelInTheList = rebels.Any(x => x.Name == buyerName);

                if (hasThatHumanInTheList)
                {
                    totalFood += 10;
                }
                else if (hasThatRebelInTheList)
                {
                    totalFood += 5;
                }

                buyerName = Console.ReadLine();
            }

            Console.WriteLine(totalFood);
        }  
    }
}
