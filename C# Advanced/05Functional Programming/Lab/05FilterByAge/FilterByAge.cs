using System;
using System.Collections.Generic;
using System.Linq;

namespace _05FilterByAge
{
    class FilterByAge
    {
        static void Main(string[] args)
        {
            int inputCount = int.Parse(Console.ReadLine());
            Dictionary<string, int> peopleData = new Dictionary<string, int>(inputCount);

            for (int i = 0; i < inputCount; i++)
            {
                string[] nameAndAge = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = nameAndAge[0];
                int age = int.Parse(nameAndAge[1]);

                if (!peopleData.ContainsKey(name))
                {
                    peopleData.Add(name, age);
                }
                else
                {
                    peopleData[name] = (age);
                }
            }
            string condition = Console.ReadLine();
            int borderAge = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            var filter = CreateFilter(condition, borderAge);
            var printer = CreatePrinter(format);
            foreach (var person in peopleData)
            {
                if (filter(person))
                {
                    printer(person);
                }
            }
           
        }
        static Func<KeyValuePair<string, int>, bool> CreateFilter(string condition, int age)
        {
            if (condition == "younger")
            {
                return x => x.Value < age;
            }
            else
            {
               return x => x.Value >= age;
            }
        }

        static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return x => Console.WriteLine(x.Key);

                case "age":
                    return x => Console.WriteLine(x.Value);

                case "name age":
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
