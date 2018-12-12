using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre.Models.Procedures
{
    public class Chip : Procedure
    {
        private const int happinessDecreasingIndex = 5;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.IsChipped == true)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }

            if (procedureTime > animal.ProcedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            animal.Happiness -= happinessDecreasingIndex;
            animal.IsChipped = true;
            animal.ProcedureTime -= procedureTime;

        }
    }
}
