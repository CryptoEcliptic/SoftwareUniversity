using CosmosX.Entities.Reactors.Contracts;
using CosmosX.Entities.Reactors.ReactorFactory.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CosmosX.Entities.Reactors.ReactorFactory
{
    public class ReactorFactory : IReactorFactory
    {
        public IReactor CreateReactor(string reactorTypeName, int id, Containers.Contracts.IContainer moduleContainer, int additionalParameter)
        {
            Type type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == reactorTypeName + "Reactor");

            var instance = (IReactor)Activator.CreateInstance(type, new object[] { id, moduleContainer, additionalParameter });
            return instance;
        }
    }
}
