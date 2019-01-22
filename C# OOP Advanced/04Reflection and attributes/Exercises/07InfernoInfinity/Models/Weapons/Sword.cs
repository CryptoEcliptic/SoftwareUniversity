using System;
using System.Collections.Generic;
using System.Text;
using _07InfernoInfinity.Enums;

namespace _07InfernoInfinity.Models.Weapons
{
    public class Sword : Weapon
    {
        public Sword(RarityLevel rarity, string name) 
            : base(rarity, name, 4, 6, 3)
        {
        }
    }
}
