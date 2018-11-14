using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Models.Storage
{
    public abstract class Storage
    {
        private readonly Vehicle[] garage;

        private readonly List<Product> products;

        public Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;

            this.products = new List<Product>();
            this.garage = new Vehicle[garageSlots];

            CreateGarage(vehicles);
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int GarageSlots { get; private set; }

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        public IReadOnlyCollection<Vehicle> Garage => Array.AsReadOnly(this.garage);

        public bool IsFull => Products.Sum(x => x.Weight) >= this.Capacity;


        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.garage.Length)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }
            if (this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            var vehicle = this.garage[garageSlot];

            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            var vehicle = GetVehicle(garageSlot);
            bool hasFreeSlot = deliveryLocation.Garage.Any(x => x == null);

            if (!hasFreeSlot)
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this.garage[garageSlot] = null; //vecicle moves from the soutsce storage garage

            int addedSlot = deliveryLocation.AddVehicle(vehicle); //veciche goes to a new place in the deliveryLocation garage
            return addedSlot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }
            var vehicle = GetVehicle(garageSlot);

            int numberOfUnloadedProducts = 0;
            while (!vehicle.IsEmpty && !this.IsFull)
            {
                Product product = vehicle.Unload();
                products.Add(product);
                numberOfUnloadedProducts++;
            }
            return numberOfUnloadedProducts;
        }

        private int AddVehicle(Vehicle vehicle)
        {
            int freeSlot = Array.IndexOf(this.garage, null);
            this.garage[freeSlot] = vehicle;
            return freeSlot;
        }

        private void CreateGarage(IEnumerable<Vehicle> vehicles)
        {
            int numberSlot = 0;

            foreach (var vehicle in vehicles)
            {
                this.garage[numberSlot] = vehicle;
                numberSlot++;
            }
        }


    }
}
