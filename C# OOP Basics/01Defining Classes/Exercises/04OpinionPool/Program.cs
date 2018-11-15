using System;
using System.Collections.Generic;
using System.Linq;

namespace _04OpinionPool
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int personCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < personCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person();
                person.Name = name;
                person.Age = age;

                people.Add(person);
            }

            foreach (var person in people.Where(x => x.Age > 30).OrderBy(x => x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }

        }
    }
}
