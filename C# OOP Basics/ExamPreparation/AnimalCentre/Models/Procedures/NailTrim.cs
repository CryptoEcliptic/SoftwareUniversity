using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre.Models.Procedures
{
    public class NailTrim : Procedure
    {
        private const int happinessDecreasingRate = 7;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (procedureTime > animal.ProcedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
            animal.Happiness -= happinessDecreasingRate;
            animal.ProcedureTime -= procedureTime;
        }
    }
}
