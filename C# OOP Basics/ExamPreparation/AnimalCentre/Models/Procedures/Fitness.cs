using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre.Models.Procedures
{
    public class Fitness : Procedure
    {
        private const int happinessDecreasingRate = 3;
        private const int energyIncreasingRate = 10;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (procedureTime > animal.ProcedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            animal.Happiness -= happinessDecreasingRate;
            animal.Energy += energyIncreasingRate;
            animal.ProcedureTime -= procedureTime;
        }
    }
}
