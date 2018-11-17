using System.Collections.Generic;
using System.Linq;

namespace _11PokemonTrainer
{
    public class Trainer
    {
        private string name;
        private int badgesCount;
        private List<Pokemon> pokemons;
        public Trainer(string name)
        {
            this.Name = name;
            this.BadgesCount = 0;
            this.pokemons = new List<Pokemon>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int BadgesCount
        {
            get { return badgesCount; }
            set { badgesCount = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }

        public void AddPokemon(Pokemon pokemon)
        {
            Pokemons.Add(pokemon);
        }
        
        public void DecreasePokemonHealth()
        {
            this.Pokemons.ForEach(x => x.Health -= 10);
        }
    }
}
