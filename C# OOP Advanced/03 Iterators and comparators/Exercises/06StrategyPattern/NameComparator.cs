using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06StrategyPattern
{
    public class NameComparator : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            int result = firstPerson.Name.Length.CompareTo(secondPerson.Name.Length);

            if (result == 0)
            {
                string firstPersonName = firstPerson.Name.ToLower();
                string secondPersonName = secondPerson.Name.ToLower();

                result = firstPersonName[0].CompareTo(secondPersonName[0]);
            }
            
            return result;
        }
    }
}
