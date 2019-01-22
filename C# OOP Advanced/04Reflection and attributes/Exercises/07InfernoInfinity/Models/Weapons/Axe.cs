using System;
using System.Collections.Generic;
using System.Text;
using _07InfernoInfinity.Enums;

namespace _07InfernoInfinity.Models.Weapons
{
    public class Axe : Weapon
    {
        public Axe(RarityLevel rarity, string name) 
            : base(rarity, name, 5, 10, 4)
        {
        }
    }
}
