using System;
using System.Collections.Generic;

namespace _07EqualityLogic
{
    public class StartUp
    {
        public static void Main()
        {
            SortedSet<Person> sortedPeople = new SortedSet<Person>();
            HashSet<Person> hashedPeople = new HashSet<Person>();

            int numberLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberLines; i++)
            {
                string[] personData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = personData[0];
                int age = int.Parse(personData[1]);

                Person currentPerson = new Person(name, age);
                sortedPeople.Add(currentPerson);
                hashedPeople.Add(currentPerson);
            }

            Console.WriteLine(sortedPeople.Count);
            Console.WriteLine(hashedPeople.Count);
        }
    }
}
