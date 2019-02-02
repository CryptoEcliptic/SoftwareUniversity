namespace FestivalManager.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using Entities.Contracts;

    public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            Type typeClass = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            ISet setInstance = (ISet)Activator.CreateInstance(typeClass, new object[] { name });

            return setInstance;
		}
	}




}
