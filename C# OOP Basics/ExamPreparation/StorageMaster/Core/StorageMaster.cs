using StorageMaster.Factories;
using StorageMaster.Models.Products;
using StorageMaster.Models.Storage;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        private Dictionary<string, Stack<Product>> products;
        private Dictionary<string, Storage> storages;
        private ProductFactory productFactory;
        private StorageFactory storageFactory;
        private Vehicle currentVehicle;
        

        public StorageMaster()
        {
            this.products = new Dictionary<string, Stack<Product>>();
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
            this.storages = new Dictionary<string, Storage>();
        }

        public string AddProduct(string type, double price)
        {
            Product product = this.productFactory.CreateProduct(type, price);
            if (!products.ContainsKey(type))
            {
                products[type] = new Stack<Product>();
            }
            products[type].Push(product);

            string result = $"Added {product.GetType().Name} to pool";
            return result;
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = this.storageFactory.CreateStorage(type, name);

            this.storages.Add(name, storage);

            string result = $"Registered {name}";
            return result;
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var currentStorage = storages.FirstOrDefault(x => x.Value.Name == storageName);
            currentVehicle = currentStorage.Value.GetVehicle(garageSlot);

            string result = $"Selected {currentVehicle.GetType().Name}";
            return result;
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int numberOfProducts = 0;
            foreach (var productName in productNames)
            {
                if (currentVehicle.IsFull)
                {
                    break;
                }

                if (!this.products.ContainsKey(productName) || this.products[productName].Count == 0)
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }

                var product = this.products[productName].Pop();

                this.currentVehicle.LoadProduct(product);
                numberOfProducts++;
            }
            string result = $"Loaded {numberOfProducts}/{productNames.Count()} products into {currentVehicle.GetType().Name}";

            return result;
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!this.storages.ContainsKey(sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            if (!this.storages.ContainsKey(destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            var sourceStorage = this.storages[sourceName];
            var destinationStorage = this.storages[destinationName];
            var vehicle = sourceStorage.GetVehicle(sourceGarageSlot);
            int destinationSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            string result = $"Sent {vehicle.GetType().Name} to {destinationName} (slot {destinationSlot})";

            return result;
        }
        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var currentStorage = storages[storageName];
            var currentVehicleProductsCout = currentStorage.GetVehicle(garageSlot).Trunk.Count;

            var unloadedProductsCount = currentStorage.UnloadVehicle(garageSlot);

            string result = $"Unloaded {unloadedProductsCount}/{currentVehicleProductsCout} products at {storageName}";
            return result;
        }
        //Stock(2.7/10) : [HardDrive(2), Gpu(1)]
        //Garage: [Semi|Semi|Semi|Van|empty|empty|empty|empty|empty|empty]

        public string GetStorageStatus(string storageName)
        {
            Storage currentStorage = storages[storageName];
            Dictionary<string, int> productsAndCounts = new Dictionary<string, int>();

            foreach (var product in currentStorage.Products)
            {
                string productName = product.GetType().Name;

                if (!productsAndCounts.ContainsKey(productName))
                {
                    productsAndCounts.Add(productName, 1);
                }
                else
                {
                    productsAndCounts[productName]++;
                }
            }
            double productsWeight = currentStorage.Products.Sum(x => x.Weight);
            int storageCapacity = currentStorage.Capacity;

            string[] productsAsStrings = productsAndCounts
                .OrderByDescending(p => p.Value)
                .ThenBy(p => p.Key)
                .Select(kvp => $"{kvp.Key} ({kvp.Value})")
                .ToArray();

            string storageStatus = $"Stock ({productsWeight}/{storageCapacity}): [{string.Join(", ", productsAsStrings)}]";

            string[] garageStatus = currentStorage
                .Garage
                .Select(x => x == null ? "empty" : x.GetType().Name)
                .ToArray();

            string garageLine = $"Garage: [{string.Join("|", garageStatus)}]";

            string result = storageStatus + "\n" + garageLine;

            return result;
        }

        public string GetSummary()
        {
            //AmazonWarehouse:
            //Storage worth: $1320.00
            //SofiaDistribution:
            //Storage worth: $0.00

            StringBuilder result = new StringBuilder();
            foreach (var storage in storages.OrderByDescending(x => x.Value.Products.Sum(y => y.Price)))
            {
                result.AppendLine(storage.Key + ":");
                result.AppendLine($"Storage worth: ${storage.Value.Products.Sum(x => x.Price):f2}");
            }

            return result.ToString().TrimEnd();

        }

    }
}
