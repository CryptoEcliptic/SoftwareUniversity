using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storage
{
    public class DistributionCenter : Storage
    {
        private const int Capacity = 2;
        private const int GarageSlots = 5;

        private readonly static Vehicle[] DefaultVehicles =
        {
            new Van(),
            new Van(),
            new Van()
        };

        public DistributionCenter(string name) 
            : base(name, Capacity, GarageSlots, DefaultVehicles)
        {
        }
    }
}
