using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storage
{
    public class AutomatedWarehouse : Storage
    {
        private const int Capacity = 1;
        private const int GarageSlots = 2;

        private static readonly Vehicle[] DefaultVehicles =
        {
            new Truck()
        };

        public AutomatedWarehouse(string name) 
            : base(name, Capacity, GarageSlots, DefaultVehicles)
        {
        }
    }
}
