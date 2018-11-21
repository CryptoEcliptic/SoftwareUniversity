using System;
using System.Collections.Generic;
using System.Linq;

namespace _12Google
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] arguments = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string personName = arguments[0];
                string typeData = arguments[1];

                if (!people.Any(x => x.Name == personName))
                {
                    people.Add(new Person(personName));
                }
                Person person = people.First(x => x.Name == personName);
                

                switch (typeData)
                {
                    case "company":
                        string companyName = arguments[2];
                        string department = arguments[3];
                        decimal salary = decimal.Parse(arguments[4]);
                        Company company = new Company(companyName, department, salary);
                        person.Company = company;
                        break;

                    case "parents":
                        string parentName = arguments[2];
                        string parentBirthday = arguments[3];
                        Parent parent = new Parent(parentName, parentBirthday);
                        person.Parents.Add(parent);
                        break;

                    case "children":
                        string childName = arguments[2];
                        string childBirthday = arguments[3];
                        Children child = new Children(childName, childBirthday);
                        person.Children.Add(child);
                        break;

                    case "car":
                        string carMdel = arguments[2];
                        int carSpeed = int.Parse(arguments[3]);
                        Car car = new Car(carMdel, carSpeed);
                        person.Car = car;
                        break;

                    case "pokemon":
                        string pokName = arguments[2];
                        string pokType = arguments[3];
                        Pokemon pokemon = new Pokemon(pokName, pokType);
                        person.Pokemons.Add(pokemon);
                        break;
                        
                    default:
                        break;
                }
                input = Console.ReadLine();
            }

            string personToPrintInfo = Console.ReadLine();

            var personToPrint = people.FirstOrDefault(x => x.Name == personToPrintInfo);

            if (personToPrint != null)
            {
                Console.WriteLine(personToPrint.ToString());
            }
        }
    }
}
