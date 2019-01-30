using NUnit.Framework;
using StorageMaster;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storage;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StorageMester.Tests.Structure
{

    [TestFixture]
    public class StorageTests
    {
        private Type storage;

        [SetUp]
        public void Setup()
        {
            this.storage = GetTypes("Storage");
        }

        [Test]
        public void ValidateAllStorages()
        {
            string[] storages = new string[]
            {
                "AutomatedWarehouse", "DistributionCenter", "Warehouse", "Storage"
            };

            foreach (var storage in storages)
            {
                Type storageType = GetTypes(storage);

                Assert.That(storageType, Is.Not.Null, $"Class {storage} not found!");
            }
        }

        [Test]
        public void ValidateStorageConstructors()
        {
            BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;

            ConstructorInfo constructor = this.storage.GetConstructors(flags).FirstOrDefault();

            Assert.That(constructor, Is.Not.Null, "No constructor found");

            var parameters = constructor.GetParameters();

            Assert.That(parameters[0].ParameterType, Is.EqualTo(typeof(string)), "Parameter" +
                "should be of type string");

            Assert.That(parameters[1].ParameterType, Is.EqualTo(typeof(int)), "Parameter" +
               "should be of type int");

            Assert.That(parameters[2].ParameterType, Is.EqualTo(typeof(int)), "Parameter" +
             "should be of type int");

            Assert.That(parameters[3].ParameterType, Is.EqualTo(typeof(IEnumerable<Vehicle>)), "Parameter" +
            "should be of type IEnumerable<Vehicle>");
        }

        [Test]
        public void ValidateStorageChildClasses()
        {
            Type[] expectedChildren = new Type[]
            {
                GetTypes("AutomatedWarehouse"),
                GetTypes("DistributionCenter"),
                GetTypes("Warehouse")
            };

            foreach (var child in expectedChildren)
            {
                Assert.That(child.BaseType, Is.EqualTo(storage));
            }
        }

        [Test]
        public void ValidateStorageFields()
        {
            var vehicleArray = storage.GetField("garage", BindingFlags.NonPublic | BindingFlags.Instance);
            var products = storage.GetField("products", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.That(vehicleArray, Is.Not.Null, "No field with name \"garage\" found");
            Assert.That(products, Is.Not.Null, "No field with name \"products\" found");
        }

        [Test]
        public void ValidateStorageIsAbstracsClass()
        {
            Assert.That(storage.IsAbstract, "Storage class should be abstract class");
        }

        [Test]
        public void ValidateStorageProperties()
        {
            Dictionary<string, Type> expectedProperties = new Dictionary<string, Type>
            {
                {"Name", typeof(string) },
                {"Capacity", typeof(int) },
                {"GarageSlots", typeof(int) },
                {"IsFull", typeof(bool) },
                {"Garage", typeof(IReadOnlyCollection<Vehicle>) },
                {"Products", typeof(IReadOnlyCollection<Product>) }
            };

            PropertyInfo[] actualProperties = storage.GetProperties();

            foreach (var property in actualProperties)
            {
                bool validProperty = expectedProperties.Any(x => x.Key == property.Name
                && x.Value == property.PropertyType);

                Assert.That(validProperty, $"Property {property} should not present in" +
                    $" Storage class");
            }
        }

        [Test]
        public void ValidateStogateMethods()
        {
            var expectedMethods = new List<Method>
            {
                new Method(typeof(Vehicle), "GetVehicle", typeof(int)),
                new Method(typeof(int), "SendVehicleTo", typeof(int), typeof(Storage)),
                new Method(typeof(int), "UnloadVehicle", typeof(int))
            };

            foreach (var expectedMethod in expectedMethods)
            {
                MethodInfo currentMethod = this.storage.GetMethod(expectedMethod.Name);

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

        private Type GetTypes(string storage)
        {
            Type targetType = typeof(StartUp)
                 .Assembly
                 .GetTypes()
                 .FirstOrDefault(x => x.Name == storage);

            return targetType;
        }
    }
}
