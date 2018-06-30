using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02HornetComm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PrivateMessage> privateMessages = new List<PrivateMessage>();
            List<Broadcast> broadcastCollection = new List<Broadcast>();

            string hornetInput = Console.ReadLine();
            while (hornetInput != "Hornet is Green")
            {
                string messagePattern = @"^([0-9]+) <-> ([A-Za-z0-9]+)$";
                Match messageReg = Regex.Match(hornetInput, messagePattern);
                bool isPrivateMessage = false;

                if (messageReg.Success)
                {
                    isPrivateMessage = true;
                }

                string broadcastPattern = @"^([^0-9]+) <-> ([A-Za-z0-9]+)$";
                Match broadcast = Regex.Match(hornetInput, broadcastPattern);
                bool isBroadcast = false;
                if (broadcast.Success)
                {
                    isBroadcast = true;
                }

                if (isPrivateMessage)
                {
                    string recepientCode = messageReg.Groups[1].ToString();
                    string reversedCode = null;
                    for (int i = recepientCode.Length - 1; i >= 0; i--)
                    {
                        reversedCode += recepientCode[i];
                    }

                    string message = messageReg.Groups[2].ToString();
                    PrivateMessage messageCollection = new PrivateMessage(); //Invoke class
                    messageCollection.Code = reversedCode;
                    messageCollection.Message = message;
                    privateMessages.Add(messageCollection);
                }

                else if (isBroadcast)
                {
                    string message = broadcast.Groups[1].ToString();
                    string frequency = broadcast.Groups[2].ToString();
                    char[] frequencySize = frequency.ToCharArray(); //Converting string to char array in order to manipulate particular symbols
                    string sizedFrequency = null;
                    for (int i = 0; i < frequencySize.Length; i++)
                    {
                        if (char.IsUpper(frequencySize[i]))
                        {
                            frequencySize[i] = char.ToLower(frequencySize[i]); //Make Upper char -> Lower
                            sizedFrequency += frequencySize[i]; //Concatinating char array to string
                        }

                        else if (char.IsLower(frequency[i]))
                        {
                            frequencySize[i] = char.ToUpper(frequencySize[i]); //Make Lower char -> Upper
                            sizedFrequency += frequencySize[i]; //Concatinating char array to string
                        }

                        else
                        {
                            sizedFrequency += frequencySize[i]; //Concatinating char array to string
                        }

                    }

                    Broadcast broadcasts = new Broadcast(); //Invoke class
                    broadcasts.Message = message;
                    broadcasts.Frequency = sizedFrequency;
                    broadcastCollection.Add(broadcasts);
                }
                hornetInput = Console.ReadLine();
            }
            if (broadcastCollection.Count > 0 )
            {
                Console.WriteLine($"Broadcasts:");
                foreach (var item in broadcastCollection)
                {
                    Console.WriteLine($"{item.Frequency} -> {item.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Broadcasts:");
                Console.WriteLine($"None");
            }

            if (privateMessages.Count > 0)
            {
                Console.WriteLine($"Messages:");
                foreach (var item in privateMessages)
                {
                    Console.WriteLine($"{item.Code} -> {item.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Messages:");
                Console.WriteLine($"None");
            }
            
        }
    }
   
}
