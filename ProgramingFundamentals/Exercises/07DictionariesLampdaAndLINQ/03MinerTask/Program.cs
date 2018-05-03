using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();
            string mineralCommand = Console.ReadLine();
            int quantity = 0;
            string minerals = "";

            while (mineralCommand != "stop")
            {
                minerals = mineralCommand;
                quantity = int.Parse(Console.ReadLine());

                if (!resources.ContainsKey(minerals))
                {
                    resources.Add(minerals, quantity);
                }
                else
                {
                    resources[minerals] += quantity; 
                }

                mineralCommand = Console.ReadLine();
            }
            foreach (var kvp in resources)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
