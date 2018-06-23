using System;

namespace _01RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int gamesCount = int.Parse(Console.ReadLine());
            double headSetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double countHeadset = 0;
            double countMouse = 0;
            double countKeyboard = 0;
            double countDisplay = 0;
            int currentGame = 0;
            int trashesKB = 0;

            for (int i = 1; i <= gamesCount ; i++)
            {
                currentGame = i;
                if (currentGame % 2 == 0)
                {
                    countHeadset++;
                }
                if (currentGame % 3 == 0)
                {
                    countMouse++;
                }
                if (currentGame % 2 == 0 && currentGame % 3 == 0)
                {
                    countKeyboard++;
                    trashesKB++;
                    if (trashesKB > 0 && trashesKB % 2 == 0)
                    {
                        countDisplay++;
                    }
                }
                
            }
            double totalExpence = (countHeadset * headSetPrice) + (countMouse * mousePrice) + (countKeyboard * keyboardPrice)
                + (countDisplay * displayPrice);

            Console.WriteLine($"Rage expenses: {totalExpence:f2} lv.");
        }
    }
}
