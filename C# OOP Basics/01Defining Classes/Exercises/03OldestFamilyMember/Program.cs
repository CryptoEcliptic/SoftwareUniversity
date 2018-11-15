using System;

namespace _03OldestFamilyMember
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int membersCount = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < membersCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);
                family.AddMembers(person);
            }

            Person oldestOne = family.GetOldestMember();

            Console.WriteLine($"{oldestOne.Name} {oldestOne.Age}");

            
        }
    }
}
