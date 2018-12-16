using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private int happiness;
        private int energy;


        protected Animal(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
            this.Owner = "Centre";
            this.IsAdopt = false;
            this.IsChipped = false;
            this.IsVaccinated = false;
        }

        public int Energy
        {
            get
            {
                return energy;
            }

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }
                energy = value;
            }
        }

        public int Happiness
        {
            get
            {
                return happiness;
            }

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }
                happiness = value;
            }
        }


        public string Name { get; private set; }

        public int ProcedureTime { get; set; }

        public string Owner { get; set; }

        public bool  IsAdopt{ get; set; }

        public bool IsChipped  { get; set; }

        public bool IsVaccinated { get; set; }


    }
}
