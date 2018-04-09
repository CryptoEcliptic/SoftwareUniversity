using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19TheaThePhotographer
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberPicturesTaken = int.Parse(Console.ReadLine());
            double filterTimeSeconds = int.Parse(Console.ReadLine());
            double persentageGoodPictures = double.Parse(Console.ReadLine());
            double uploadTime = int.Parse(Console.ReadLine());

            double timeForFilteringPictures = numberPicturesTaken * filterTimeSeconds;
            double picturesForUpload = Math.Ceiling((numberPicturesTaken * (persentageGoodPictures / 100)));
            double timeForUpload = uploadTime * picturesForUpload;
            double totalTimeNeededInSeconds = timeForUpload + timeForFilteringPictures;
            TimeSpan time = TimeSpan.FromSeconds(totalTimeNeededInSeconds); //Calling method to convert integer to timeValue(seconds)
            string totalTime = time.ToString(@"d\:hh\:mm\:ss"); // Converting seconds to d/hh/mm/ss;

            Console.WriteLine(totalTime);
        }
    }
}
