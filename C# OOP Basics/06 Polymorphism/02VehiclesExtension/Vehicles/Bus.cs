using System;

namespace _02VehiclesExtension.Vehicles
{
    public class Bus : Vehicle
    {
        private const double airConditioningFuel = 1.4;
        public bool isBusFull = true;
        
        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }
        
        public override void Drive(double distance)
        {
            if (isBusFull)
            {
                double fullBusConsumption = this.FuelConsumption + airConditioningFuel;
                ReduceFuel(fullBusConsumption, distance);           
            }
            else
            {
                ReduceFuel(this.FuelConsumption, distance);
            }

        }

        private void ReduceFuel(double consumption, double distance)
        {
            double fuelUsed = distance * consumption;
            if (fuelUsed > this.FuelQuantity)
            {
                throw new ArgumentException("Bus needs refueling");
            }
            else if(fuelUsed < this.FuelQuantity)
            {
                this.FuelQuantity -= fuelUsed;
                Console.WriteLine($"Bus travelled {distance} km");
            }
        }
    }
}
