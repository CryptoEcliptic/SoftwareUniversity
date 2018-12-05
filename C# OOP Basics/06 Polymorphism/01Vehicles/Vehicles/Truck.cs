using System;
using System.Collections.Generic;
using System.Text;

namespace _01Vehicles.Vehicles
{
    public class Truck : Vehicle
    {
        private const double maxReservoirCapacityPercent = 0.95;
        private const double airConditioningFuel = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += airConditioningFuel;
        }

        public override void Refuel(double quantity)
        {
            this.FuelQuantity += quantity * maxReservoirCapacityPercent;
        }

        public override void Drive(double distance)
        {
            double fuelUsed = distance * this.FuelConsumption;
            if (fuelUsed > this.FuelQuantity)
            {
                Console.WriteLine("Truck needs refueling");
            }
            else
            {
                this.FuelQuantity -= fuelUsed;
                Console.WriteLine($"Truck travelled {distance} km");
            }

        }
    }
}
