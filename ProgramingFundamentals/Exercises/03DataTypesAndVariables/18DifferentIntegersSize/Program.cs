using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18DifferentIntegersSize
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isCapable = false;
            string number = Console.ReadLine();
            string message = "";

            try
            {
                sbyte sByteNum = sbyte.Parse(number);
                isCapable = true;
                message = message + "* sbyte\n";
            }
            catch (Exception)
            {

            }
            try
            {
                byte byteNum = byte.Parse(number);
                isCapable = true;
                message = message + "* byte\n";
            }
            catch (Exception)
            {
            }
            try
            {
                short shortNum = short.Parse(number);
                isCapable = true;
                message = message + "* short\n";
            }
            catch (Exception)
            {
            }
            try
            {
                ushort ushortNum = ushort.Parse(number);
                isCapable = true;
                message = message + "* ushort\n";
            }
            catch (Exception)
            {
            }
            try
            {
                int intNum = int.Parse(number);
                isCapable = true;
                message = message + "* int\n";
            }
            catch (Exception)
            {
            }
            try
            {
                uint uintNum = uint.Parse(number);
                isCapable = true;
                message = message + "* uint\n";
            }
            catch (Exception)
            {
            }
            try
            {
                long longNum = long.Parse(number);
                isCapable = true;
                message = message + "* long\n";
            }
            catch (Exception)
            {
            }
            if (isCapable == true)
            {
                Console.WriteLine($"{number} can fit in:");
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine($"{number} can't fit in any type");
            }
        }
    }
}
