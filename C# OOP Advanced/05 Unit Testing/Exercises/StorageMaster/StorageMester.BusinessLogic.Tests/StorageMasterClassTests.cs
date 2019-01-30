using NUnit.Framework;
using StorageMaster;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storage;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StorageMester.BusinessLogic.Tests
{
    [TestFixture]
    public class StorageMasterClassTests
    {
        Type storagemaster;
        object instance;

        [SetUp]
        public void Setup()
        {
            storagemaster = GetType("StorageMaster");
            this.instance = Activator.CreateInstance(storagemaster, new object[] { });
        }

        [Test]
        public void CheckIfAllMethodsAreAvailable()
        {
            MethodInfo[] actualMethods = storagemaster.GetMethods();
            List<Method> expectedMethods = new List<Method>
            {
                new Method("AddProduct", typeof(string), typeof(double)),
                new Method("RegisterStorage", typeof(string), typeof(string)),
                new Method("SelectVehicle", typeof(string), typeof(int)),
                new Method("LoadVehicle", typeof(IEnumerable<string>)),
                new Method("SendVehicleTo", typeof(string), typeof(int), typeof(string)),
                new Method("UnloadVehicle", typeof(string), typeof(int)),
                new Method("GetStorageStatus", typeof(string)),
                new Method("GetSummary")
            };

            foreach (var method in expectedMethods)
            {
                MethodInfo currentMethod = storagemaster.GetMethod(method.Name);
                Assert.That(currentMethod, Is.Not.Null, "Method doesn't exist");
            }
        }

        [Test]
        public void ValidteAddProductMethod()
        {
            var addMethod = storagemaster.GetMethod("AddProduct");

            string product = "Gpu";
            double price = 2.50;
            string expectedResult = $"Added {product} to pool";
            string actualResult = (string)addMethod.Invoke(instance,
                new object[] { product, price });

            Assert.That(expectedResult, Is.EqualTo(actualResult), "Method AddProduct " +
                "is not working properly");
        }

        [Test]
        public void ValidateRegisterStorageMethod()
        {
            var registerStorageMethod = storagemaster.GetMethod("RegisterStorage");

            string type = "Warehouse";
            string name = "Main Storage";
            string expectedResult = $"Registered {name}";
            string actualResult = (string)registerStorageMethod.Invoke(instance,
                new object[] { type, name });

            Assert.That(expectedResult, Is.EqualTo(actualResult), "Method RegisterStorage " +
                "is not working properly");
        }

        [Test]
        public void ValidateSendVehicleToMethod()
        {
            var registerStorageMethod = storagemaster.GetMethod("RegisterStorage");
            var instance = Activator.CreateInstance(storagemaster);

            string firstStorageType = "DistributionCenter";
            string firstName = "Gosho";

            string secondStorageType = "AutomatedWarehouse";
            string secondName = "Pesho";

            registerStorageMethod.Invoke(instance, new object[]
            { firstStorageType, firstName });
            registerStorageMethod.Invoke(instance, new object[]
            { secondStorageType, secondName });

            var actualResult = storagemaster.GetMethod("SendVehicleTo").Invoke(instance,
                new object[] { "Gosho", 0, "Pesho" });

            var expectedResult = $"Sent Van to Pesho (slot 1)";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ValidateSelectVehicleMethod()
        {
            string type = "Warehouse";
            string name = "DHL";
            var registerStorageMethod = storagemaster.GetMethod("RegisterStorage");
            var storage = registerStorageMethod.Invoke(instance,
                new object[] { type, name });

            var selectVehicleMethod = storagemaster.GetMethod("SelectVehicle");

            int garageSlot = 1;
            string expectedResult = "Selected Semi";
            var actualResult = selectVehicleMethod.Invoke(instance,
                 new object[] { name, garageSlot });

            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void ValidateLoadVehicleMethod()
        {
            Stack<Product> stackProducts = new Stack<Product>();
            stackProducts.Push(new Gpu(2.50));
            stackProducts.Push(new Ram(2.80));

            Dictionary<string, Stack<Product>> productsPool = new Dictionary<string, Stack<Product>>
            {
                {"Ram", stackProducts },
                { "Gpu", stackProducts}
            };

            IEnumerable<string> productNames = new string[]
            {
                "Gpu", "Ram"
            };

            var loadVehicleMethod = storagemaster.GetMethod("LoadVehicle");

            var vehicle = storagemaster.GetField("currentVehicle",
                BindingFlags.NonPublic | BindingFlags.Instance);
            vehicle.SetValue(instance, new Van());

            var collection = storagemaster.GetField("productsPool", BindingFlags.NonPublic |
                BindingFlags.Instance);
            collection.SetValue(instance, productsPool);

            var method = loadVehicleMethod.Invoke(instance, new object[] { productNames });

            var expectedResult = "Loaded 2/2 products into Van";

            Assert.That(method, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ValidateLoadVehicleMethodThrowsExceptionIfProductNotFound()
        {
            IEnumerable<string> productNames = new string[]
            {
                "Gpu", "Ram"
            };

            Stack<Product> stackProducts = new Stack<Product>();
            stackProducts.Push(new SolidStateDrive(2.50));
            stackProducts.Push(new HardDrive(2.80));

            Dictionary<string, Stack<Product>> productsPool = new Dictionary<string, Stack<Product>>
            {
                {"SolidStateDrive", stackProducts },
                { "HardDrive", stackProducts}
            };
         
            var loadVehicleMethod = storagemaster.GetMethod("LoadVehicle");

            var vehicle = storagemaster.GetField("currentVehicle",
                BindingFlags.NonPublic | BindingFlags.Instance);
            vehicle.SetValue(instance, new Van());

            var collection = storagemaster.GetField("productsPool", BindingFlags.NonPublic |
                BindingFlags.Instance);
            collection.SetValue(instance, productsPool);

            Assert.Throws<TargetInvocationException>(() => loadVehicleMethod
            .Invoke(instance, new object[] { productNames }));
        }

        [Test]
        public void ValidateUnloadVehicleMethod()
        {
            var registerStorageMethod = storagemaster.GetMethod("RegisterStorage");
            
            string storageType = "Warehouse";
            string name = "Fedex";
            registerStorageMethod.Invoke(instance, new object[]
            { storageType, name });

            var unloadMethod = storagemaster.GetMethod("UnloadVehicle");
            var unloadResult = unloadMethod.Invoke(instance, new object[] { "Fedex", 0 });
            string expectedResult = "Unloaded 0/0 products at Fedex";

            Assert.That(expectedResult, Is.EqualTo(unloadResult));
        }

        [Test]
        public void ValidateGetStorageStatusMethod()
        {
            var registerStorageMethod = storagemaster.GetMethod("RegisterStorage");
            string storageType = "Warehouse";
            string name = "Fedex";
            registerStorageMethod.Invoke(instance, new object[]
            { storageType, name });


            var storageStatusMethod = storagemaster.GetMethod("GetStorageStatus");
            string actualResult = (string)storageStatusMethod.Invoke(instance, 
                new object[] {"Fedex" });

            string expectedResult = "Stock (0/10): []" +
                "\r\nGarage: [Semi|Semi|Semi|empty|empty|empty|empty|empty|empty|empty]";

            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void ValidateGetSummaryMethod()
        {
            //Get RegisterStogage method
            var storageMethod = storagemaster.GetMethod("RegisterStorage");

            //Invoke RegisterStorage method and create Fedex Warehouse
            storageMethod.Invoke(instance, new object[] 
            { "Warehouse", "Fedex" });
            //Invoke RegisterStorage method and create DHL Warehouse
            storageMethod.Invoke(instance, new object[]
            { "Warehouse", "DHL" });
            //Both Storages are added in the instance repository
            //(Dictionaty<string, Storage> storageRegistry)

            //Getting instance repository as FieldInfo
            FieldInfo repository = storagemaster.GetField("storageRegistry", 
                BindingFlags.NonPublic | BindingFlags.Instance);

            //Getting the value of the repository and casting it to Dictionary.
            //Without casting it is an object and cannot be used.
            var storages = (Dictionary<string, Storage>)repository.GetValue(instance);

            //Get Fedex warehouse, get it's vehicle, load the vehicle and unload it in the storage.
            Storage storageFedex = storages["Fedex"];
            Vehicle fedexVehicle = storageFedex.GetVehicle(0);
            fedexVehicle.LoadProduct(new Gpu(2.50));
            storageFedex.UnloadVehicle(0);

            //Get DHL warehouse, get it's vehicle, load the vehicle and unload it in the storage.
            Storage storageDHL = storages["DHL"];
            Vehicle DHLVehicle = storageDHL.GetVehicle(0);
            DHLVehicle.LoadProduct(new HardDrive(15.55));
            storageDHL.UnloadVehicle(0);

            var getSummaryMethod = storagemaster.GetMethod("GetSummary");
            string actualResult = (string)getSummaryMethod.Invoke(instance, new object[] { });
            string expectedResult = "DHL:\r\nStorage worth: $15.55\r\nFedex:\r\nStorage worth: $2.50";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        private Type GetType(string nameClass)
        {
            Type targetType = typeof(StartUp)
            .Assembly
            .GetTypes()
            .FirstOrDefault(x => x.Name == nameClass);

            return targetType;
        }

        private class Method
        {
            public Method(string name, params Type[] inputParams)
            {
                this.ReturnType = typeof(string);
                this.Name = name;
                this.InputParamateres = inputParams;
            }

            public Type ReturnType { get; set; }

            public string Name { get; set; }

            public Type[] InputParamateres { get; set; }
        }
    }
}





