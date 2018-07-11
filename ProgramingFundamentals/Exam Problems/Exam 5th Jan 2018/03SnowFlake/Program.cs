using System;
using System.Text.RegularExpressions;

namespace _03SnowFlake
{
    class Program
    { 
        static void Main(string[] args)
        {
            string surface1 = Console.ReadLine();
            string mantle1 = Console.ReadLine();
            string core = Console.ReadLine();
            string mantle2 = Console.ReadLine();
            string surface2 = Console.ReadLine();

            string corePattern;
            bool hasCoreValid;
            ValidCore(out corePattern, out hasCoreValid);

            bool hasMantleValid1, hasMantleValid2;
            string mantlePattern;
            ValidMantle(out hasMantleValid1, out hasMantleValid2, out mantlePattern);

            string surfacePatterm;
            bool hasSurfaceValid1, hasSurfaceValid2;
            ValidSurface(out surfacePatterm, out hasSurfaceValid1, out hasSurfaceValid2);

            string allPattern;
            bool allValid;
            isAllValid(corePattern, mantlePattern, surfacePatterm, out allPattern, out allValid);

            if (Regex.IsMatch(surface1, surfacePatterm))
            {
                hasSurfaceValid1 = true;
            }

            if (Regex.IsMatch(surface2, surfacePatterm))
            {
                hasSurfaceValid2 = true;
            }

            if (Regex.IsMatch(mantle1, mantlePattern))
            {
                hasMantleValid1 = true;
            }

            if (Regex.IsMatch(mantle2, mantlePattern))
            {
                hasMantleValid2 = true;
            }

            if (Regex.IsMatch(core, allPattern))
            {
                hasCoreValid = true;
            }

            if (hasSurfaceValid1 && hasSurfaceValid2 && hasMantleValid1 && hasMantleValid2 && hasCoreValid)
            {
                allValid = true;
            }

            Match coreMatch = Regex.Match(core, corePattern);
            int countCore = coreMatch.Length;

            if (allValid)
            {
                Console.WriteLine("Valid");
                Console.WriteLine(countCore);
            }

            else
            {
                Console.WriteLine("Invalid");
            }

        }

        private static void isAllValid(string corePattern, string mantlePattern, string surfacePatterm, out string allPattern, out bool allValid)
        {
            allPattern = @"^[\D\W]+([\d_])+([a-zA-ZА-Яа-я]+)([\d_]+)[\D\W]";
            //$"{surfacePatterm}{mantlePattern}{corePattern}{mantlePattern}{surfacePatterm}";
            allValid = false;
        }

        private static void ValidCore(out string corePattern, out bool hasCoreValid)
        {
            corePattern = @"(?<core>[a-zA-Z]+)";
            hasCoreValid = false;
        }

        private static void ValidMantle(out bool hasMantleValid1, out bool hasMantleValid2, out string mantlePattern)
        {
            hasMantleValid1 = false;
            hasMantleValid2 = false;
            mantlePattern = @"(?<mantle>[\d|_]+)";
        }

        private static void ValidSurface(out string surfacePatterm, out bool hasSurfaceValid1, out bool hasSurfaceValid2)
        {
            surfacePatterm = @"(?<surface>[^a-zA-Z0-9])";
            hasSurfaceValid1 = false;
            hasSurfaceValid2 = false;
        }
    }
}
