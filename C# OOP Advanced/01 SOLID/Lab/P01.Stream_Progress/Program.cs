using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            string name = "Pesho";
            string album = "Pesho's songs";
            int lenght = 15;
            int bytesSent = 64;

            IStreamable music = new Music(name, album, lenght, bytesSent);
            IStreamable file = new File(name, lenght, bytesSent);

            StreamProgressInfo streamCalc = new StreamProgressInfo(music);
            int result = streamCalc.CalculateCurrentPercent();

            Console.WriteLine(result);

        }
    }
}
