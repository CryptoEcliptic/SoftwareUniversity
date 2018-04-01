using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Balls
{
    class Program
    {
        static void Main(string[] args)
        {
            int ballsCount = int.Parse(Console.ReadLine());
            int totalPoints = 0;
            int redBalls = 0;
            int yellowBalls = 0;
            int orangeBalls = 0;
            int whiteBalls = 0;
            int blackBalls = 0;
            int otherColours = 0;
            for (int i = 1; i <= ballsCount; i++)
            {
                string ballColour = Console.ReadLine();

                if (ballColour == "red")
                {
                    totalPoints += 5;
                    redBalls++;
                }
                else if (ballColour == "orange")
                {
                    totalPoints += 10;
                    orangeBalls++;
                }
                else if (ballColour == "yellow")
                {
                    totalPoints += 15;
                    yellowBalls++;
                }
                else if (ballColour == "white")
                {
                    totalPoints += 20;
                    whiteBalls++;
                }
                else if (ballColour == "black")
                {
                    totalPoints = totalPoints / 2;
                    blackBalls++;
                }
                else
                {
                    otherColours++;
                }
            }
            Console.WriteLine($"Total points: {totalPoints}");
            Console.WriteLine($"Points from red balls: {redBalls}\nPoints from orange balls: {orangeBalls}");
            Console.WriteLine($"Points from yellow balls: {yellowBalls}\nPoints from white balls: {whiteBalls}");
            Console.WriteLine($"Other colors picked: {otherColours}\nDivides from black balls: {blackBalls}");
        }
    }
}
