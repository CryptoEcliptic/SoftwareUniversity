using System;
using System.Collections.Generic;
using System.Text;

namespace _01Vehicles.Vehicles
{
    public class Car : Vehicle
    {
        private const double airConditioningFuel = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += airConditioningFuel;
        }

        public override void Drive(double distance)
        {
            double fuelUsed = distance * this.FuelConsumption;
            if (fuelUsed > this.FuelQuantity)
            {
                Console.WriteLine("Car needs refueling");
            }
            else
            {
                this.FuelQuantity -= fuelUsed;
                Console.WriteLine($"Car travelled {distance} km");
            }

        }
    }
}
