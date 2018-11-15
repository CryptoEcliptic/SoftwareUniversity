using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03OldestFamilyMember
{
    public class Family
    {
        private List<Person> familyMembers;

        public Family()
        {
            this.familyMembers = new List<Person>();
        }

        public void AddMembers(Person person)
        {
            if (person == null)
            {
                throw new Exception();
            }
            this.familyMembers.Add(person);
        }

        public Person GetOldestMember()
        {
            return this.familyMembers.OrderByDescending(x => x.Age).FirstOrDefault();
        }
    }
}
