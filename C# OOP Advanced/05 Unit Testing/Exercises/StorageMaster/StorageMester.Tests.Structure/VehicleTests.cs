using NUnit.Framework;
using StorageMaster;
using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StorageMester.Tests.Structure
{
    [TestFixture]
    public class VehicleTests
    {
        private Type vehicle;

        [SetUp]
        public void Setup()
        {
            this.vehicle = this.GetType("Vehicle");
        }

        [Test]
        public void ValidateAllVehicles()
        {
            string[] vehicles = new string[]
            {
            "Semi", "Truck", "Van", "Vehicle"
            };

            foreach (var vehicle in vehicles)
            {
                var currentType = GetType(vehicle);

                Assert.That(currentType, Is.Not.Null, $"{currentType} doesn't exists");
            }
        }

        [Test]
        public void ValidateConstructors()
        {
            var flags = BindingFlags.NonPublic | BindingFlags.Instance;

            var constructor = vehicle.GetConstructors(flags).FirstOrDefault();

            Assert.That(constructor, Is.Not.Null, "Constructor doesn't exist");

            var parameters = constructor.GetParameters();

            Assert.That(parameters[0].ParameterType, Is.EqualTo(typeof(int)));
        }

        [Test]
        public void ValidateVehicleChildClasses()
        {
            Type[] derivedTypes = new Type[]
              {
                GetType("Semi"),
                GetType("Truck"),
                GetType("Van")
            };

            foreach (var derivedType in derivedTypes)
            {
                Assert.That(derivedType.BaseType, Is.EqualTo(vehicle), $"{derivedType} doesn't inherit {vehicle}!");
            }
        }

        [Test]
        public void ValidateVehicleProperties()
        {
            PropertyInfo[] actualProperties = vehicle.GetProperties();

            var expectedProperties = new Dictionary<string, Type>
            {
                { "Capacity", typeof(int) },
                { "Trunk", typeof(IReadOnlyCollection<Product>) },
                { "IsFull", typeof(bool) },
                { "IsEmpty", typeof(bool) }
            };

            foreach (var actualProperty in actualProperties)
            {
                bool isValidProperty = expectedProperties.Any(x => x.Key == actualProperty.Name 
                && actualProperty.PropertyType == x.Value);

                Assert.That(isValidProperty, $"{actualProperty.Name} doesn't exists!");
            }
        }

        [Test]
        public void ValidateVehicleMethods()
        {
            var expectedMethods = new List<Method>
            {
                new Method(typeof(void), "LoadProduct", typeof(Product)),
                new Method(typeof(Product), "Unload")
            };

            foreach (var expectedMethod in expectedMethods)
            {
                MethodInfo currentMethod = vehicle.GetMethod(expectedMethod.Name);

                Assert.That(currentMethod, Is.Not.Null, $"{expectedMethod.Name} method doesn't exists");

                bool currentMethodReturnType = currentMethod.ReturnType == expectedMethod.ReturnType;

                Assert.That(currentMethodReturnType, $"{expectedMethod.Name} invalid return type");

                var expectedMethodParms = expectedMethod.InputParamateres;
                var actualParms = currentMethod.GetParameters();

                for (int i = 0; i < expectedMethodParms.Length; i++)
                {
                    var actualParam = actualParms[i].ParameterType;
                    var expectedParam = expectedMethodParms[i];

                    Assert.AreEqual(expectedParam, actualParam);
                }
            }
        }

        [Test]
        public void ValidateVehicleIsAbstract()
        {
            Assert.That(vehicle.IsAbstract, $"Vehicle class must be abstract!");
        }

        [Test]
        public void ValidateVehicleFields()
        {
            var trunkField = vehicle.GetField("trunk", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.That(trunkField, Is.Not.Null, $"Invalid field");
        }

        private class Method
        {
            public Method(Type returnType, string name, params Type[] inputParams)
            {
                this.ReturnType = returnType;
                this.Name = name;
                this.InputParamateres = inputParams;
            }

            public Type ReturnType { get; set; }

            public string Name { get; set; }

            public Type[] InputParamateres { get; set; }
        }

        private Type GetType(string vehicle)
        {
            Type type = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x =>x.Name == vehicle);

            return type;
        }
    }
}
