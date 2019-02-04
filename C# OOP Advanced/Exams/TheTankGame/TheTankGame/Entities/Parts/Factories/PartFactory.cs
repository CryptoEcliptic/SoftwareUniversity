using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TheTankGame.Entities.Parts.Contracts;
using TheTankGame.Entities.Parts.Factories.Contracts;

namespace TheTankGame.Entities.Parts.Factories
{
    public class PartFactory : IPartFactory
    {
        public IPart CreatePart(string partType, string model, double weight, decimal price,
            int additionalParameter)
        {
            Type typeClass = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(x => x.Name == partType + "Part");

            IPart instance = (IPart)Activator.CreateInstance(typeClass,
                new object[] { model, weight, price, additionalParameter });

            return instance;
        }
    }
}
