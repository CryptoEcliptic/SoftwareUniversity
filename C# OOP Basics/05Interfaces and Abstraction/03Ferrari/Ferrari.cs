using _03Ferrari.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03Ferrari
{
    public class Ferrari : IFerrari
    {
        private string model = "488-Spider";
        private string driver;

        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public string Driver
        {
            get { return driver; }
            set { driver = value; }
        }

        public string Model
        {
            get { return model = "488-Spider"; }
        }

        public string PushBreaks()
        {
            return "Brakes!";
        }

        public string PushGas()
        {
           return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.PushBreaks()}/{this.PushGas()}/{this.Driver}";
        }
    }
}
