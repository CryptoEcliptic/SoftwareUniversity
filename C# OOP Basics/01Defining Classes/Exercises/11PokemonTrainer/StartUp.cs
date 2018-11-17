using System;
using System.Collections.Generic;
using System.Linq;

namespace _11PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string arguments = Console.ReadLine();

            while (arguments != "Tournament")
            {
                string[] pokemonData = arguments.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = pokemonData[0];
                string pokemonName = pokemonData[1];
                string element = pokemonData[2];
                int health = int.Parse(pokemonData[3]);

                Pokemon currentPokemon = new Pokemon(pokemonName, element, health);
  
                if (!trainers.Any(x => x.Name == trainerName))
                {
                    trainers.Add(new Trainer(trainerName));
                }
                Trainer trainer = trainers.First(x => x.Name == trainerName);
                trainer.AddPokemon(currentPokemon);

                arguments = Console.ReadLine();
            }

            arguments = Console.ReadLine();

            while (arguments != "End")
            {
                string currentElement = arguments;

                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == currentElement))
                    {
                        trainer.BadgesCount++;
                    }
                    else
                    {
                        trainer.DecreasePokemonHealth();
                        trainer.Pokemons = trainer.Pokemons.Where(x => x.Health > 0).ToList();
                    }
                }
                arguments = Console.ReadLine();
            }
    
            foreach (var trainer in trainers.OrderByDescending(x => x.BadgesCount))
            {
                Console.WriteLine($"{trainer.Name} {trainer.BadgesCount} {trainer.Pokemons.Count}");
            }
        }
    }
}
