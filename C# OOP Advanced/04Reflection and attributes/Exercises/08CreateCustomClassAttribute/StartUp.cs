using System;

namespace _08CreateCustomClassAttribute
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var classType = typeof(Weapon);
            var attributes = classType.GetCustomAttributes(false);

            foreach (var attr in attributes)
            {
                var classAttr = attr as ClassAttribute;

                if (classAttr != null)
                {
                    string command = Console.ReadLine(); ;

                    while (command != "END")
                    {
                        switch (command)
                        {
                            case "Author":
                                Console.WriteLine($"Author: {classAttr.Author}");
                                break;
                            case "Revision":
                                Console.WriteLine($"Revision: {classAttr.Revision}");
                                break;
                            case "Description":
                                Console.WriteLine($"Class description: {classAttr.Description}");
                                break;
                            case "Reviewers":
                                Console.WriteLine($"Reviewers: {String.Join(", ", classAttr.Reviewers)}");
                                break;
                        }

                        command = Console.ReadLine();
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
