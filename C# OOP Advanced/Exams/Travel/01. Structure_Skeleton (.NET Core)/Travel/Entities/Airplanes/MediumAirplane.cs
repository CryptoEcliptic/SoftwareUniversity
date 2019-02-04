using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Entities.Airplanes
{
    public class MediumAirplane : Airplane
    {
        private const int MediumSeats = 10;
        private const int MediumBaggageCompartments = 14;

        public MediumAirplane() 
            : base(MediumSeats, MediumBaggageCompartments)
        {
        }
    }
}
