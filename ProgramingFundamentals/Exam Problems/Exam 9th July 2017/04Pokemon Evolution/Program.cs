using System;
using System.Collections.Generic;
using System.Linq;

namespace _04Pokemon_Evolution
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<Evolution>> dataPokemons = new Dictionary<string, List<Evolution>>();

            while (input != "wubbalubbadubdub")
            {

                if (input.Contains("->"))
                {
                    string[] pokemons = input
                        .Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string name = pokemons[0];
                    string evolutionType = pokemons[1];
                    int indexEvolution = int.Parse(pokemons[2]);

                    Evolution evolutions = new Evolution();
                    evolutions.evolutionName = evolutionType;
                    evolutions.evolutionIndex = indexEvolution;

                    if (!dataPokemons.ContainsKey(name))
                    {
                        List<Evolution> current = new List<Evolution>();
                        current.Add(evolutions);
                        dataPokemons.Add(name, current);
                    }

                    else if (dataPokemons.ContainsKey(name))
                    {
                        List<Evolution> current = new List<Evolution>();
                        current.Add(evolutions);
                        dataPokemons[name].Add(evolutions);
                    }
                }

                else
                {
                    string name = input;
                    if (dataPokemons.ContainsKey(name))
                    {
                        Console.WriteLine($"# {name}");

                        foreach (var kvp in dataPokemons[name])
                        {
                            Console.WriteLine($"{kvp.evolutionName} <-> {kvp.evolutionIndex}");
                        }
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var pokemon in dataPokemons)
            {
                Console.WriteLine($"# {pokemon.Key}");
                foreach (var evol in pokemon.Value.OrderByDescending(x => x.evolutionIndex))
                {
                    Console.WriteLine($"{evol.evolutionName} <-> {evol.evolutionIndex}");
                }
            }

        }
    }
    class Evolution
    {
        public string evolutionName { get; set; }
        public int evolutionIndex { get; set; }
    }
}
