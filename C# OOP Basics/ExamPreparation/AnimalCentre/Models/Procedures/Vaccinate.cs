using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre.Models.Procedures
{
    public class Vaccinate : Procedure
    {
        private const int energyDecreasingRate = 8;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (procedureTime > animal.ProcedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
            animal.Energy -= energyDecreasingRate;
            animal.ProcedureTime -= procedureTime;
            animal.IsVaccinated = true;
        }
    }
}
