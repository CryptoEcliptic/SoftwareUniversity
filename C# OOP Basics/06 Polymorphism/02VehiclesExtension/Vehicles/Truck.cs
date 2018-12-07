using System;

namespace _02VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double maxReservoirCapacityPercent = 0.95;
        private const double airConditioningFuel = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += airConditioningFuel;

        }

        public override void Refuel(double quantity)
        {
            base.Refuel(quantity);
            this.FuelQuantity += quantity * maxReservoirCapacityPercent;
        }
        
        public override void Drive(double distance)
        {
            double fuelUsed = distance * this.FuelConsumption;
            if (fuelUsed > this.FuelQuantity)
            {
                throw new ArgumentException("Truck needs refueling");
            }
            else
            {
                this.FuelQuantity -= fuelUsed;
                Console.WriteLine($"Truck travelled {distance} km");
            }

        }
    }
}
