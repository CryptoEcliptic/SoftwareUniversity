namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type classType = Type.GetType("P02_BlackBoxInteger.BlackBoxInteger");

            var blackBoxInstance = Activator.CreateInstance(classType, true);

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] arguments = input.Split("_");
                string name = arguments[0];
                int value = int.Parse(arguments[1]);

                MethodInfo currentMethod = classType.GetMethod(name, BindingFlags.NonPublic | BindingFlags.Instance); //Call specific method via its name
                currentMethod.Invoke(blackBoxInstance, new object[] { value }); //Invoke the current method
                var result = classType
                    .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .First(x => x.Name == "innerValue")
                    .GetValue(blackBoxInstance); //Return result getting innevValue field from the class
         
                Console.WriteLine(result);
                input = Console.ReadLine();
            }
        }
    }
}
