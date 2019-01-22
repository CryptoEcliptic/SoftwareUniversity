using _07InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07InfernoInfinity.Contracts
{
    public interface IGem
    {
        GemCondition GemCondition { get; }

        int Strength { get; }

        int Agility { get; }

        int Vitality { get; }

        void IncreaseGemStats();
    }
}
