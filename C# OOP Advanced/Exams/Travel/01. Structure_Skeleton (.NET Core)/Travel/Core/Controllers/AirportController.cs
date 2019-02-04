namespace Travel.Core.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Contracts;
	using Entities;
	using Entities.Contracts;
	using Entities.Factories;
	using Entities.Factories.Contracts;
    using Travel.Entities.Airplanes;
    using Travel.Entities.Airplanes.Contracts;
    using Travel.Entities.Items;
    using Travel.Entities.Items.Contracts;

    public class AirportController : IAirportController
	{
		private const int BagValueConfiscationThreshold = 3000;

		private IAirport airport;

		private IAirplaneFactory airplaneFactory = null;
		private IItemFactory itemFactory;

		public AirportController(IAirport airport)
		{
			this.airport = airport;
			this.airplaneFactory = new AirplaneFactory();
			this.itemFactory = new ItemFactory();
		}

		public string RegisterPassenger(string username)
		{
			if (this.airport.GetPassenger(username) != null)
			{
				throw new InvalidOperationException($"Passenger {username} already registered!");
			}

			var passenger = new Passenger(username);
			this.airport.AddPassenger(passenger);

			return $"Registered {passenger.Username}";
		}

        public string RegisterTrip(string source, string destination, string planeType)
        {
            IAirplane airplane = this.airplaneFactory.CreateAirplane(planeType);

            var trip = new Trip(source, destination, airplane);
            this.airport.AddTrip(trip);

            return $"Registered trip {trip.Id}";
        }

        public string RegisterBag(string username, IEnumerable<string> bagItems)
		{
			var passenger = this.airport.GetPassenger(username);

            List<IItem> items = new List<IItem>();
            foreach(var item in bagItems)
            {
                IItem currentItem = this.itemFactory.CreateItem(item);
                items.Add(currentItem);
            }
			
			var bag = new Bag(passenger, items);
			passenger.Bags.Add(bag);

			return $"Registered bag with {string.Join(", ", items.Select(x => x.GetType().Name))} for {username}";
		}

		public string CheckIn(string username, string tripId, IEnumerable<int> bagIndices)
		{
			var passenger = this.airport.GetPassenger(username);
            ITrip trip = this.airport.GetTrip(tripId);
            bool ckeckedIn = trip.Airplane.Passengers.Any(x => x.Username == username);
            if (ckeckedIn)
            {
                throw new InvalidOperationException($"{username} is already checked in!");
            }

			int confiscatedBags = CheckInBags(passenger, bagIndices);
			trip.Airplane.AddPassenger(passenger);

			return
				$"Checked in {passenger.Username} with {bagIndices.Count() - confiscatedBags}/{bagIndices.Count()} checked in bags";
		}

		private int CheckInBags(IPassenger passenger, IEnumerable<int> bagsToCheckIn)
		{
			var bags = passenger.Bags;

			var confiscatedBagCount = 0;
			foreach (var i in bagsToCheckIn)
			{
				var currentBag = bags[i];
				bags.RemoveAt(i);

				if (ShouldConfiscate(currentBag))
				{
					airport.AddConfiscatedBag(currentBag);
					confiscatedBagCount++;
				}
				else
				{
					this.airport.AddCheckedBag(currentBag);
				}
			}

			return confiscatedBagCount;
		}

		private static bool ShouldConfiscate(IBag bag)
		{
			var luggageValue = 0;

			for (int i = 0; i < bag.Items.Count; i++)
			{
				luggageValue += bag.Items.ToArray()[i].Value;
			}

			bool shouldConfiscate = luggageValue > BagValueConfiscationThreshold;
			return shouldConfiscate;
		}

		
	}
}