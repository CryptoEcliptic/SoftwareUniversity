using _01Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01Vehicles.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public virtual void Drive(double distance)
        {
            double fuelUsed = distance * this.FuelConsumption;
            this.FuelQuantity -= fuelUsed;
        }

        public virtual void Refuel(double quantity)
        {
            this.FuelQuantity += quantity;
        }
    }
}
