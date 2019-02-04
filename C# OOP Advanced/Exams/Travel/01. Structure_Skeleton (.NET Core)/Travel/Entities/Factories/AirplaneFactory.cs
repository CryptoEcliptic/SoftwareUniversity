namespace Travel.Entities.Factories
{
    using Airplanes.Contracts;
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
            Type typeName = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            IAirplane instance = (IAirplane)Activator.CreateInstance(typeName);

            return instance;
		}
	}
}