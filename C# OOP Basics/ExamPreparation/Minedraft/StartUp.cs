using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var manager = new DraftManager();
        string input = Console.ReadLine();

        while (true)
        {
            string[] tokens = input.Split().ToArray();
            var args = tokens.Skip(1).ToList();
            string result = string.Empty;
            string command = tokens[0];

            try
            {
                switch (command)
                {
                    case "Shutdown":
                        result = manager.ShutDown();
                        break;

                    case "RegisterHarvester":
                        result = manager.RegisterHarvester(args);
                        break;

                    case "RegisterProvider":
                        result = manager.RegisterProvider(args);
                        break;

                    case "Day":
                        result = manager.Day();
                        break;

                    case "Mode":
                        result = manager.Mode(args);
                        break;

                    case "Check":
                        result = manager.Check(args);
                        break;

                    default:
                        break;
                }
            }
            catch (ArgumentException ae)
            {
                result = ae.Message;
            }

            Console.WriteLine(result);
            if (command == "Shutdown")
            {
                return;
            }

            input = Console.ReadLine();
        }

    }
}
