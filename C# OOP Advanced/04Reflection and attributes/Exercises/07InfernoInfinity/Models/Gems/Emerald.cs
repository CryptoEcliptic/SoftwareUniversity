using System;
using System.Collections.Generic;
using System.Text;
using _07InfernoInfinity.Enums;

namespace _07InfernoInfinity.Models.Gems
{
    public class Emerald : Gem
    {
        public Emerald(GemCondition gemCondition) 
            : base(gemCondition, 1, 4, 9)
        {
        }
    }
}
