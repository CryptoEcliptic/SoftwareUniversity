using System;

namespace _02ExtendedDatabase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Person[] peoples = new Person[]
            {
                new Person(123, "Gosho"),
                new Person(123456, "Ivan"),
                new Person(007, "Zoran"),
                new Person(125, "Stavri"),
                new Person(978, "Jordan")
            };

            Database database = new Database(peoples);
            database.Remove();

            Person[] peopleReturn = database.Fetch();
            foreach (var p in peopleReturn)
            {
                Console.WriteLine($"{p.Username} {p.Id}");
            }
        }
    }
}
