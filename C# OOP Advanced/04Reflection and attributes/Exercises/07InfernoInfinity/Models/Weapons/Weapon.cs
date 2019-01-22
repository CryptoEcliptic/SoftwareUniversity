using _07InfernoInfinity.Contracts;
using _07InfernoInfinity.Enums;
using _07InfernoInfinity.Models.Gems;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07InfernoInfinity.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int baseMinDamage;
        private int baseMaxDamage;
        private int strength;
        private int agility;
        private int vitality;
        
        private IGem[] gems;

        private RarityLevel rarity;

        public Weapon(RarityLevel rarity, string name, int baseMinDamage, int baseMaxDamage, int numberOfSockets)
        {
            this.Rarity = rarity;
            this.Name = name;
            this.BaseMinDamage = baseMinDamage;
            this.BaseMaxDamage = baseMaxDamage;
            this.gems = new Gem[numberOfSockets];
            
        }

        public IReadOnlyCollection<IGem> Gems => Array.AsReadOnly(gems);

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public int BaseMinDamage
        {
            get { return baseMinDamage; }
            private set { baseMinDamage = value; }
        }

        public int BaseMaxDamage
        {
            get { return baseMaxDamage; }
            private set { baseMaxDamage = value; }
        }

        public int MaxDamage
        {
            get
            {
                return this.BaseMaxDamage * (int)Rarity + this.Gems
                    .Where(x => x != null)
                    .Sum(x => x.Strength * 3 + x.Agility * 4);
            }
        }

        public int MinDamage
        {
            get
            {
                return this.BaseMinDamage * (int)Rarity + this.Gems
                    .Where(x => x != null)
                    .Sum(x => x.Strength * 2 + x.Agility);
            }
        }

        public RarityLevel Rarity
        {
            get
            {
                return rarity;
            }
            private set
            {
                rarity = value; 
            }
        }

        public void AddGem(int index, IGem gem)
        {
            if (index >= 0 && index < this.Gems.Count)
            {
                this.gems[index] = gem;
            }
        }

        public void RemoveGem(int index)
        {
            if (index >= 0 && index < this.Gems.Count)
            {
                this.gems[index] = null;
            }
        }

        public override string ToString()
        {
            foreach (var gem in gems.Where(x => x != null)) 
            {
                this.strength += gem.Strength;
                this.agility += gem.Agility;
                this.vitality += gem.Vitality;
            }

            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{this.strength} Strength, +{this.agility} Agility, " +
                $"+{this.vitality} Vitality";
        }

       
    }
}
