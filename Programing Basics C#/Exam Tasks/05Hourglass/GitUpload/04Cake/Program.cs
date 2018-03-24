using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeLength = int.Parse(Console.ReadLine());
            int cakeSize = cakeWidth * cakeLength;
            int takenPieces = 0;
            int piecesLeft = 0;

            for (int i = 1; i <= cakeSize; i++)
            {
                string pieces = Console.ReadLine(); //Input is read as a string

                if (pieces == "STOP") //if the string pieces is STOP
                {
                    piecesLeft = cakeSize - takenPieces;
                    Console.WriteLine($"{piecesLeft} pieces are left.");
                    break;
                }
                else
                    takenPieces += int.Parse(pieces); //pieces converts to int.

                if (takenPieces > cakeSize) //If the int takenPeases becomes larger than cakeSize
                {
                    Console.WriteLine($"No more cake left! You need {takenPieces - cakeSize} pieces more.");
                    break;
                }
            }
        }
    }
}
