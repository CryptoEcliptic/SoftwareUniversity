using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            bool haveShadowmourne = false;
            bool haveValanyr = false;
            bool haveDragonwrath = false;
            int quantity = 0;
            string inputRresources = "";
            string prize = "";

            SortedDictionary<string, int> resourses = new SortedDictionary<string, int>();
            resourses.Add("shards", 0);  //adding the resourses that are going to be counted
            resourses.Add("fragments", 0);
            resourses.Add("motes", 0);
            Dictionary<string, int> junk = new Dictionary<string, int>(); 

            while (haveShadowmourne == false & haveValanyr == false & haveDragonwrath == false)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                for (int i = 0; i < input.Length; i += 2) //every input pair contain two elements. Thus i+=2
                {
                    quantity = int.Parse(input[i]);
                    inputRresources = input[i + 1].ToLower();

                    if (resourses.ContainsKey(inputRresources)) // checking if certain resourses are available and add more quantity.
                    {
                        resourses[inputRresources] += quantity; // adding quantity if certain resourses are met.
                    }
                    else if (!junk.ContainsKey(inputRresources))
                    {
                        junk.Add(inputRresources, quantity);
                    }
                    else
                    {
                        junk[inputRresources] += quantity;
                    }
                    if (resourses["shards"] >= 250)
                    {
                        haveShadowmourne = true;
                        prize = "Shadowmourne";
                        resourses["shards"] -= 250;
                        break;
                    }
                    else if (resourses["fragments"] >= 250)
                    {
                        haveValanyr = true;
                        prize = "Valanyr";
                        resourses["fragments"] -= 250;
                        break;
                    }
                    else if (resourses["motes"] >= 250)
                    {
                        haveDragonwrath = true;
                        prize = "Dragonwrath";
                        resourses["motes"] -= 250;
                        break;
                    }
                }
            }

            Console.WriteLine($"{prize} obtained!");

            foreach (var pair in resourses.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

            foreach (var junkStaff in junk.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{junkStaff.Key}: {junkStaff.Value}");
            }
        }
    }
}
