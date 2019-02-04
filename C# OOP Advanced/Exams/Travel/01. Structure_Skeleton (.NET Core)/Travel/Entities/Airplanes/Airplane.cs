using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travel.Entities.Airplanes.Contracts;
using Travel.Entities.Contracts;

namespace Travel.Entities.Airplanes
{
    public abstract class Airplane : IAirplane
    {
        private List<IBag> baggageCompartment;
        private List<IPassenger> passengers;

        protected Airplane(int seats, int baggageCompartments)
        {
            this.Seats = seats;
            this.BaggageCompartments = baggageCompartments;

            this.baggageCompartment = new List<IBag>();
            this.passengers = new List<IPassenger>();
        }

        public int BaggageCompartments { get; private set; }

        public int Seats { get; private set; }

        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment.AsReadOnly();

        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();

        public bool IsOverbooked => this.passengers.Count > this.Seats;

        public void AddPassenger(IPassenger passenger)
        {
            passengers.Add(passenger);
        }

        public IPassenger RemovePassenger(int seat) //TODO Check if index is valid
        {
            IPassenger passangerToRemove = this.passengers[seat];
            this.passengers.RemoveAt(seat);

            return passangerToRemove;
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            var bagsToRemove = this.baggageCompartment.Where(x => x.Owner == passenger).ToList();

            this.baggageCompartment.RemoveAll(x => x.Owner == passenger); //TODO Check if works

            return bagsToRemove;
        }

        public void LoadBag(IBag bag)
        {
            if (this.baggageCompartment.Count >= this.BaggageCompartments)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name}!");
            }
            baggageCompartment.Add(bag);
        }

    }
}
