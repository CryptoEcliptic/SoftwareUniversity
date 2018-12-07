using System;

namespace _02VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double airConditioningFuel = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption = this.FuelConsumption + airConditioningFuel;
        }

        public override void Drive(double distance)
        {
            double fuelUsed = distance * this.FuelConsumption;
            if (fuelUsed > this.FuelQuantity)
            {
                throw new ArgumentException("Car needs refueling");
            }
            else
            {
                this.FuelQuantity -= fuelUsed;
                Console.WriteLine($"Car travelled {distance} km");
            }

        }
    }
}
