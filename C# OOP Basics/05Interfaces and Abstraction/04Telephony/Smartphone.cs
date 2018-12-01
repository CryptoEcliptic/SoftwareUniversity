using _04Telephony.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04Telephony
{
    public class Smartphone : IBrowsable, ICallable
    {
        //private string number;
        //private string webSites;

        //public string Websites
        //{
        //    get { return webSites; }
        //    set { webSites = value; }
        //}

        //public string Number
        //{
        //    get { return number; }
        //    set { number = value; }
        //}

        public void Call(string number)
        {
            if (number.All(x => char.IsDigit(x)))
            {
                Console.WriteLine($"Calling... {number}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
            
        }

        public void Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                Console.WriteLine("Invalid URL!");
            }
            else
            {
                Console.WriteLine($"Browsing: {url}!");
            }
        }
    }
}
