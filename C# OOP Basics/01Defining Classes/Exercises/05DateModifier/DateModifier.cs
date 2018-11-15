using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace _05DateModifier
{
    public class DateModifier
    {
        private string startDate;
        private string endDate;

        public DateModifier(string startDate, string endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public string EndDate
        {
            get { return this.endDate; }
            
            set
            {
                this.endDate = value;
            }
        }

        public string StartDate
        {
            get { return startDate; }
            set
            {
                this.startDate = value;
            }
        }

        public void CalculateDifference()
        {
           int difference;
            DateTime startAsDate = DateTime.ParseExact(startDate, "yyyy MM dd", CultureInfo.InvariantCulture);
            DateTime endAsDate = DateTime.ParseExact(endDate, "yyyy MM dd", CultureInfo.InvariantCulture);

            difference = Math.Abs((startAsDate - endAsDate).Days);

            Console.WriteLine(difference);
        }
    }
}
