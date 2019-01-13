 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type typeClass = Type.GetType("P01_HarvestingFields.HarvestingFields");

            FieldInfo[] allFields = typeClass.GetFields(BindingFlags.NonPublic | BindingFlags.Public
                | BindingFlags.Static | BindingFlags.Instance);

            string input = Console.ReadLine();

            while (input != "HARVEST")
            {
                if (input == "all")
                {
                    foreach (var field in allFields)
                    {
                        Console.WriteLine($"{field.Attributes.ToString().ToLower().Replace("family", "protected")} " +
                        $"{field.FieldType.Name} {field.Name}");
                    }
                }
                else
                {
                    FieldInfo[] fieldsToPrint = allFields
                    .Where(x => x.Attributes
                    .ToString()
                    .ToLower()
                    .Replace("family", "protected") == input)
                    .ToArray();

                    foreach (var field in fieldsToPrint)
                    {
                        Console.WriteLine($"{field.Attributes.ToString().ToLower().Replace("family", "protected")} " +
                            $"{field.FieldType.Name} {field.Name}");
                    }
                }
                
                input = Console.ReadLine();
            }
        }
    }
}
