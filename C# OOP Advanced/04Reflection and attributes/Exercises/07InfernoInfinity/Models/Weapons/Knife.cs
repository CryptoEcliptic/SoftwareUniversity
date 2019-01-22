using System;
using System.Collections.Generic;
using System.Text;
using _07InfernoInfinity.Enums;

namespace _07InfernoInfinity.Models.Weapons
{
    public class Knife : Weapon
    {
        public Knife(RarityLevel rarity, string name) 
            : base(rarity, name, 3, 4, 2)
        {
        }
    }
}
