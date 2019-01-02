using System;
using System.Collections.Generic;

namespace _06StrategyPattern
{
    public class StartUp
    {
        public static void Main()
        {
            NameComparator nameComparison = new NameComparator();
            AgeComparator ageComparison = new AgeComparator();

            SortedSet<Person> peopleByName = new SortedSet<Person>(nameComparison);
            SortedSet<Person> peopleByAge = new SortedSet<Person>(ageComparison);

            int numberLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberLines; i++)
            {
                string[] personData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = personData[0];
                int age = int.Parse(personData[1]);

                Person currentPerson = new Person(name, age);
                peopleByName.Add(currentPerson);
                peopleByAge.Add(currentPerson);
            }

            foreach (var person in peopleByName)
            {
                Console.WriteLine(person);
            }

            foreach (var person in peopleByAge)
            {
                Console.WriteLine(person.ToString());
            }


        }
    }
}
