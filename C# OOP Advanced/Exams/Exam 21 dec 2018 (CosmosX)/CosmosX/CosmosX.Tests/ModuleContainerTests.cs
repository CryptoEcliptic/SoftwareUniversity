namespace CosmosX.Tests
{
    using CosmosX.Entities.Containers;
    using CosmosX.Entities.Modules.Absorbing;
    using CosmosX.Entities.Modules.Absorbing.Contracts;
    using CosmosX.Entities.Modules.Energy;
    using CosmosX.Entities.Modules.Energy.Contracts;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class ModuleContainerTests
    {
        private const int containerCapacity = 20;
        private ModuleContainer moduleContainer;

        [SetUp]
        public void Setup()
        {
            this.moduleContainer = new ModuleContainer(containerCapacity);
        }

        [Test]
        public void ValidateModuleContainerCtor()
        {
            ConstructorInfo constructor = this.moduleContainer
                .GetType()
                .GetConstructors()
                .FirstOrDefault();

            Assert.That(constructor, Is.Not.Null, "No constructor found");
        }

        [Test]
        public void ValidateCtorParams()
        {
            ConstructorInfo constructor = this.moduleContainer
                .GetType()
                .GetConstructors()
                .FirstOrDefault();

            var parameters = constructor.GetParameters();
            Assert.That(parameters[0].ParameterType, Is.EqualTo(typeof(int)), "Parameter" +
                "should be of type int");

        }

        [Test]
        public void TestAddEnergyModuleValidation()
        {
            IEnergyModule energyModule = new CryogenRod(1, 15);

            this.moduleContainer.AddEnergyModule(energyModule);

            //Method should add energyModule
            long expectedResult = 15;
            long actualResult = this.moduleContainer.TotalEnergyOutput;
            Assert.That(actualResult, Is.EqualTo(expectedResult), "Total energy output should be 15");

            //Method should throws exceptio if no parameter is provided
            Assert.Throws<ArgumentException>(() => this.moduleContainer.AddEnergyModule(null), "Method should throws ArgumentException");
        }

        [Test]
        public void AddAbsorbingModuleMethod()
        {
            IAbsorbingModule absorbongyModule = new HeatProcessor(2, 20);

            this.moduleContainer.AddAbsorbingModule(absorbongyModule);

            //Method should add energyModule
            long expectedResult = 20;
            long actualResult = this.moduleContainer.TotalHeatAbsorbing;
            Assert.That(actualResult, Is.EqualTo(expectedResult), "Total energy output should be 20");

            //Method should throws exceptio if no parameter is provided
            Assert.Throws<ArgumentException>(() => this.moduleContainer.AddAbsorbingModule(null), "Method should throws ArgumentException");
        }

        [Test]
        public void TestModuleContainerCapacity()
        {
            var fullModuleContainer = new ModuleContainer(3);

            var energyModules = new List<IEnergyModule>()
            {
                { new CryogenRod(1, 15) },
                { new CryogenRod(2, 20) },
                { new CryogenRod(3, 25) },
                { new CryogenRod(4, 30) },

            };

            for (int i = 0; i < energyModules.Count; i++)
            {
                fullModuleContainer.AddEnergyModule(energyModules[i]);
            }

            var expectedResult = 75; //sum of the energy outputs of the 2, 3 and 4 elements in the energyModules collection

            var actualResult = fullModuleContainer.TotalEnergyOutput;

            Assert.That(actualResult, Is.EqualTo(expectedResult), "Total energy output should be 75");
        }
    }
}