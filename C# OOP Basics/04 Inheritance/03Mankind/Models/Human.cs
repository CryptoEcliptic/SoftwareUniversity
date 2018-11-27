using System;

namespace _03Mankind.Models
{
    public class Human
    {
        private string firstName;
        private string secondName;

        public Human(string firstName, string secondName)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
        }

        public string FirstName
        {
            get { return firstName; }
            protected set
            {
                if (char.IsLower(value[0]))
                {
                    Exception ae = new ArgumentException("Expected upper case letter! Argument: firstName");
                    Console.WriteLine(ae.Message);
                    Environment.Exit(0);
                }
                else if (value.Length <= 3)
                {
                    Exception ae = new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                    Console.WriteLine(ae.Message);
                    Environment.Exit(0);
                }
                firstName = value;
            }
        }

        public string SecondName
        {
            get { return secondName; }
            protected set
            {
                if (char.IsLower(value[0]))
                {
                    Exception ae = new ArgumentException("Expected upper case letter! Argument: lastName");
                    Console.WriteLine(ae.Message);
                    Environment.Exit(0);
                }
                else if (value.Length <= 2)
                {
                    Exception ae = new ArgumentException("Expected length at least 3 symbols! Argument: lastName ");
                    Console.WriteLine(ae.Message);
                    Environment.Exit(0);
                }
                secondName = value;
            }
        }
    }
}
