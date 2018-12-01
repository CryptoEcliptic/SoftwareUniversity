using System;
using System.Collections.Generic;
using System.Text;

namespace _04Telephony.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] inputNumber = Console.ReadLine().Split();
            string[] inputURL = Console.ReadLine().Split();
           
                for (int i = 0; i < inputNumber.Length; i++)
                {
                    string number = inputNumber[i];
                    Smartphone currentSmartphone = new Smartphone();
                    currentSmartphone.Call(number);
                }

                for (int i = 0; i < inputURL.Length; i++)
                {
                    string url = inputURL[i];
                    Smartphone currentSmartphone = new Smartphone();
                    currentSmartphone.Browse(url);
                }
        }
    }
}
