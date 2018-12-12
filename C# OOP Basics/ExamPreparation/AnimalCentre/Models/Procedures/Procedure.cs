using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        private List<IAnimal> procedureHistory;

        public Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
        }

        protected IAnimal Animal { get; set; }

        public IReadOnlyCollection<IAnimal> ProcedureHistory => this.procedureHistory.AsReadOnly();

        public string History()
        {
            return $"{this.GetType().Name}\n    - {this.Animal.Name} - Happiness: {this.Animal.Happiness}" +
            $" - Energy: {this.Animal.Energy}";
        }

        public abstract void DoService(IAnimal animal, int procedureTime);
    }
}
