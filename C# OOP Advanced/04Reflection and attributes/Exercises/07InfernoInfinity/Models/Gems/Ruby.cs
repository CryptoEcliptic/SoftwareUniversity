using System;
using System.Collections.Generic;
using System.Text;
using _07InfernoInfinity.Enums;

namespace _07InfernoInfinity.Models.Gems
{
    public class Ruby : Gem
    {
        public Ruby(GemCondition gemCondition) 
            : base(gemCondition, 7, 2, 5)
        {
        }
    }
}
