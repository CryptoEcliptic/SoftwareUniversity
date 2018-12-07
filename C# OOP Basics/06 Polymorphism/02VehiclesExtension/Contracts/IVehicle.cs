using System;
using System.Collections.Generic;
using System.Text;

namespace _02VehiclesExtension
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        double TankCapacity { get; }

        void Drive(double distance);

        void Refuel(double quantity);
    }
}
