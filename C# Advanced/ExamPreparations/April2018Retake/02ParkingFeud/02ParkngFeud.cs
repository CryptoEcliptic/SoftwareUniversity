using System;
using System.Collections.Generic;
using System.Linq;

namespace _02ParkingFeud
{
    class ParkingFeud
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimentions[0];
            int cols = dimentions[1];

            int samEntrance = int.Parse(Console.ReadLine());
            bool succesfulParking = false;
            CreateAndFillParkingArea(rows, cols);

            while (succesfulParking == false)
            {
                string[] targetParkingLots = Console.ReadLine().Split(' ').ToArray();
            }

        }

        private static void CreateAndFillParkingArea(int rows, int cols)
        {
            List<List<string>> parking = new List<List<string>>();
            int number = 1;

            for (int i = 0; i < rows; i++)
            {
                List<string> currentRow = new List<string>();
                char letter = 'A';
                for (int j = 0; j < cols; j++)
                {

                    string name = letter + number.ToString();
                    currentRow.Add(name);
                    letter++;
                }
                parking.Add(currentRow);
                number++;
            }
        }
    }
}
