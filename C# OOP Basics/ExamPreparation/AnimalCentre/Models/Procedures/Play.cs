using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre.Models.Procedures
{
    public class Play : Procedure
    {
        private const int energyIncreasingRate = 6;
        private const int happinessIncreasingRate = 12;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (procedureTime > animal.ProcedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
            animal.Energy -= energyIncreasingRate;
            animal.Happiness += happinessIncreasingRate;
            animal.ProcedureTime -= procedureTime;
        }
    }
}
