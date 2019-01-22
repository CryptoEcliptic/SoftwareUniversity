using System;
using System.Collections.Generic;
using System.Text;
using _07InfernoInfinity.Enums;

namespace _07InfernoInfinity.Models.Gems
{
    public class Amethyst : Gem
    {
        public Amethyst(GemCondition gemCondition)
            : base(gemCondition, 2, 8, 4)
        {
        }
    }
}
