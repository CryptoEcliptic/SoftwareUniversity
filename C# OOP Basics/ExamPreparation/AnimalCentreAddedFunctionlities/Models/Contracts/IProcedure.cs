using AnimalCentre.Models.Animals;
using System.Collections.Generic;

namespace AnimalCentre.Models.Contracts
{
    public interface IProcedure
    {
        IReadOnlyCollection<IAnimal> ProcedureHistory { get; }

        string History();

        IAnimal Animal { get; }
    }
}
