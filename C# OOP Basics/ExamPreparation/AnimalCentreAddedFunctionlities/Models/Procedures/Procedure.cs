using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected List<IAnimal> procedureHistory; //TODO check whether access modifier is correct

        public Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
        }

        public IReadOnlyCollection<IAnimal> ProcedureHistory => this.procedureHistory.AsReadOnly();

        public IAnimal Animal { get; private set; }

        public abstract void DoService(IAnimal animal, int procedureTime);

        public string History() //TODO check that method
        {
            //StringBuilder sb = new StringBuilder();
            //foreach (var animal in procedureHistory)
            //{
            //    sb.AppendLine($"{this.GetType().Name}\n    - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            //}
            return $"{this.GetType().Name}\n    - {Animal.Name} - Happiness: {Animal.Happiness} - Energy: {Animal.Energy}";
        }
    }
}
