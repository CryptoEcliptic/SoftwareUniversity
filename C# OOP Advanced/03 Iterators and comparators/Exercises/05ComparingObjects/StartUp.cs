using System;
using System.Collections.Generic;

namespace _05ComparingObjects
{
    public class StartUp
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] arguments = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = arguments[0];
                int age = int.Parse(arguments[1]);
                string town = arguments[2];

                Person currentPerson = new Person(name, age, town);
                people.Add(currentPerson);
                
                input = Console.ReadLine();
            }

            int personPorition = int.Parse(Console.ReadLine()) - 1;

            Person referentPerson = people[personPorition];
            int equalPeople = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(referentPerson) == 0)
                {
                    equalPeople++;
                }
            }
            
            if (equalPeople > 1)
            {
                Console.WriteLine($"{equalPeople} {people.Count - equalPeople} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
            
        }
    }
}
