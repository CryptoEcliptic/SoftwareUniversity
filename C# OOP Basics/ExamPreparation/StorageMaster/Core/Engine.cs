using StorageMaster.Models.Products;
using StorageMaster.Models.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class Engine
    {
        private StorageMaster storagemaster;
        private List<string> productNames;
        private Dictionary<string, Stack<Product>> products;
        private Dictionary<string, Storage> storages;
        private bool isRunning;

        public Engine()
        {
            this.storagemaster = new StorageMaster();
            this.productNames = new List<string>();
            this.products = new Dictionary<string, Stack<Product>>();
            this.storages = new Dictionary<string, Storage>();
            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;
            
            string output = "";

            while (this.isRunning)
            {
                string input = Console.ReadLine();
                string[] argumentsAndCommands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    string command = argumentsAndCommands[0];
                    switch (command)
                    {
                        case "AddProduct":
                            string type = argumentsAndCommands[1];
                            double price = double.Parse(argumentsAndCommands[2]);
                            output = this.storagemaster.AddProduct(type, price);
                            break;

                        case "RegisterStorage":
                            type = argumentsAndCommands[1];
                            string name = argumentsAndCommands[2];
                            output = this.storagemaster.RegisterStorage(type, name);
                            break;

                        case "SelectVehicle":
                            string storageName = argumentsAndCommands[1];
                            int garageSlot = int.Parse(argumentsAndCommands[2]);
                            output = this.storagemaster.SelectVehicle(storageName, garageSlot);
                            break;

                        case "LoadVehicle":

                            output = this.storagemaster.LoadVehicle(argumentsAndCommands.Skip(1));
                            break;

                        case "SendVehicleTo":
                            string sourceName = argumentsAndCommands[1];
                            int sourceGarageslot = int.Parse(argumentsAndCommands[2]);
                            string destinationName = argumentsAndCommands[3];
                            output = this.storagemaster.SendVehicleTo(sourceName, sourceGarageslot, destinationName);
                            break;

                        case "UnloadVehicle":
                            storageName = argumentsAndCommands[1];
                            garageSlot = int.Parse(argumentsAndCommands[2]);
                            output = this.storagemaster.UnloadVehicle(storageName, garageSlot);
                            break;

                        case "GetStorageStatus":
                            storageName = argumentsAndCommands[1];
                            output = this.storagemaster.GetStorageStatus(storageName);
                            break;

                        case "END":
                            this.isRunning = false;
                            output = this.storagemaster.GetSummary();
                            break;

                        default:
                            break;  
                    }

                }
                catch (InvalidOperationException ae)
                {

                    output = $"Error: {ae.Message}";
                }
                Console.WriteLine(output);

            }
        }
    }
}
