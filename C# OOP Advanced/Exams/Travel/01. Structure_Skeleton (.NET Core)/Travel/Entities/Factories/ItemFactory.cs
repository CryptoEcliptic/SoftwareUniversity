namespace Travel.Entities.Factories
{
    using Contracts;
    using Items.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
            Type typeName = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            IItem instance = (IItem)Activator.CreateInstance(typeName);

            return instance;
		}
	}
}
