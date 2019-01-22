using _07InfernoInfinity.Contracts;
using _07InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07InfernoInfinity.Models.Gems
{
    public class Gem : IGem
    {
        public Gem(GemCondition gemCondition, int strength, int agility, int vitality)
        {
            this.GemCondition = gemCondition;
            this.Strength = strength;
            this.Agility = agility;
            this.Vitality = vitality;
            IncreaseGemStats();
        }

        public GemCondition GemCondition { get; private set; }

        public int Strength { get; private set; }

        public int Agility { get; private set; }

        public int Vitality { get; private set; }

        public void IncreaseGemStats()
        {
            switch (this.GemCondition)
            {
                case GemCondition.Chipped:
                    this.Strength += 1;
                    this.Agility += 1;
                    this.Vitality += 1;

                    break;
                case GemCondition.Regular:
                    this.Strength += 2;
                    this.Agility += 2;
                    this.Vitality += 2;
                    break;
                case GemCondition.Perfect:
                    this.Strength += 5;
                    this.Agility += 5;
                    this.Vitality += 5;
                    break;
                case GemCondition.Flawless:
                    this.Strength += 10;
                    this.Agility += 10;
                    this.Vitality += 10;
                    break;
                default:
                    break;
            }
        }
    }
}
