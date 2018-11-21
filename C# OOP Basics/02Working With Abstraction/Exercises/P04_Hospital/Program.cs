using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();

            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] input = command.Split();
                var departament = input[0];
                var firstName = input[1];
                var familyName = input[2];
                var patient = input[3];
                var fullName = firstName + familyName;
                AddingDoctorsAndDepartments(doctors, departments, departament, fullName);

                bool availableBeds = departments[departament].SelectMany(x => x).Count() < 60;
                AddingPatients(doctors, departments, departament, patient, fullName, availableBeds);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                PrintResult(doctors, departments, command);
                command = Console.ReadLine();
            }
        }

        private static void PrintResult(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string command)
        {
            string[] args = command.Split();

            if (args.Length == 1)
            {
                Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
            }
            else if (args.Length == 2 && int.TryParse(args[1], out int staq))
            {
                Console.WriteLine(string.Join("\n", departments[args[0]][staq - 1].OrderBy(x => x)));
            }
            else
            {
                Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
            }
        }

        private static void AddingPatients(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string departament, string patient, string fullName, bool availableBeds)
        {
            if (availableBeds)
            {
                int room = 0;
                doctors[fullName].Add(patient);
                for (int i = 0; i < departments[departament].Count; i++)
                {
                    if (departments[departament][i].Count < 3)
                    {
                        room = i;
                        break;
                    }
                }
                departments[departament][room].Add(patient);
            }
        }

        private static void AddingDoctorsAndDepartments(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string departament, string fullName)
        {
            if (!doctors.ContainsKey(fullName))
            {
                doctors[fullName] = new List<string>();
            }
            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();
                for (int stai = 0; stai < 20; stai++)
                {
                    departments[departament].Add(new List<string>());
                }
            }
        }
    }
}
