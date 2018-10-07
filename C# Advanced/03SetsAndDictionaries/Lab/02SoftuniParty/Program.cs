using System;
using System.Collections.Generic;

namespace _02SoftuniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> ordinaryGuests = new HashSet<string>();
            HashSet<string> vipGuests = new HashSet<string>();
            

            while (input != "PARTY")
            {
                string guestName = input;
                bool isVIP = false;
                for (int i = 0; i < guestName.Length; i++)
                {
                    if (Char.IsDigit(guestName[i]))
                    {
                        isVIP = true;
                        break;
                    }
                }
                if (isVIP)
                {
                    if (!vipGuests.Contains(guestName) && guestName != null)
                    {
                        vipGuests.Add(guestName);
                    }
                }
                else
                {
                    if (!ordinaryGuests.Contains(guestName) && guestName != null)
                    {
                        ordinaryGuests.Add(guestName);
                    }
                }

                input = Console.ReadLine();
            }

            string input1 = Console.ReadLine();
            while (input1 != "END")
            {
                string attendingGuest = input1;

                if (ordinaryGuests.Contains(attendingGuest))
                {
                    ordinaryGuests.Remove(attendingGuest);
                }
                else if (vipGuests.Contains(attendingGuest))
                {
                    vipGuests.Remove(attendingGuest);
                }

                input1 = Console.ReadLine();
            }

            Console.WriteLine(ordinaryGuests.Count + vipGuests.Count);
            foreach (var person in vipGuests)
            {
                Console.WriteLine(person);
            }

            foreach (var person in ordinaryGuests)
            {
                Console.WriteLine(person);
            }
        } 
    }
}
