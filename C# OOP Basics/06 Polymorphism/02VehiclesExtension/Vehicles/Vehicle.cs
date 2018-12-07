using System;

namespace _02VehiclesExtension
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption; 
        }

        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel must be a positive number");
                }

                if (value > this.TankCapacity)
                {
                    value = 0;
                }
                fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get
            {
                return fuelConsumption;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel must be a positive number");
                }
                fuelConsumption = value;
            }
        }

        public double TankCapacity
        {
            get
            {
                return tankCapacity;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel must be a positive number");
                }
                tankCapacity = value;
            }
        }

        public virtual void Drive(double distance)
        {
           
        }

        public virtual void Refuel(double quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            else if (this.FuelQuantity + quantity > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {quantity} fuel in the tank");
            }

            this.FuelQuantity += quantity;
        }


    }
}
