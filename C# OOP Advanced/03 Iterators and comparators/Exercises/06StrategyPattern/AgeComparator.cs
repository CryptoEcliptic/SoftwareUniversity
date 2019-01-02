using System;
using System.Collections.Generic;
using System.Text;

namespace _06StrategyPattern
{
    public class AgeComparator : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            int result = firstPerson.Age.CompareTo(secondPerson.Age);

            return result;
        }
    }
}
