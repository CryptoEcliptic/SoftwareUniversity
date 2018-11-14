using StorageMaster.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Models.Vehicles
{
    public abstract class Vehicle
    {
        private int capacity;
        private readonly List<Product> trunk;

        public Vehicle(int capacity)
        {
            this.trunk = new List<Product>();
            this.Capacity = capacity;
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public IReadOnlyCollection<Product> Trunk => trunk.AsReadOnly();

        public bool IsFull => this.Trunk.Sum(x => x.Weight) >= this.Capacity;
        public bool IsEmpty => !this.Trunk.Any();

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new  InvalidOperationException("Vehicle is full!");
            }

            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }

            Product lastProduct = trunk[trunk.Count - 1];
            this.trunk.RemoveAt(trunk.Count - 1);

            return lastProduct;
        }
       
    }
}
