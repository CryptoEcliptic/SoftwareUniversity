using System;
using System.Linq;

namespace _02ExtendedDatabase
{
    public class Database
    {
        private const int capacity = 16;

        private Person[] peopleCollection;
        private int indexer;

        public Database()
        {
            this.peopleCollection = new Person[capacity];
            indexer = -1;
        }

        public Database(Person[] inputPeople)
        {
            this.peopleCollection = new Person[capacity];
            indexer = -1;
            if (inputPeople.Length > capacity)
            {
                throw new InvalidOperationException();
            }

            for (int i = 0; i < inputPeople.Length; i++)
            {
                Person currentPerson = inputPeople[i];

                CheckIfPersonIsUnique(currentPerson);

                this.peopleCollection[++indexer] = currentPerson;
            }
        }

        public void Add(Person person)
        {
            if (indexer > peopleCollection.Length - 2)
            {
                throw new InvalidOperationException();
            }

            CheckIfPersonIsUnique(person);

            this.peopleCollection[++indexer] = person;
        }

        public Person Remove()
        {
            if (indexer == -1)
            {
                throw new InvalidOperationException();
            }
            Person returnElement = this.peopleCollection[indexer];
            this.peopleCollection[indexer] = null;
            indexer--;
            return returnElement;
        }

        public Person FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException();
            }

            if (!peopleCollection.Any(x => x != null && x.Username == username))
            {
                throw new InvalidOperationException();
            }
            Person personToReturn = peopleCollection.FirstOrDefault(x => x.Username == username);
            return personToReturn;
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (!peopleCollection.Any(x => x != null && x.Id == id))
            {
                throw new InvalidOperationException();
            }
            Person personToReturn = peopleCollection.FirstOrDefault(x => x.Id == id);
            return personToReturn;
        }

        public Person[] Fetch()
        {
            return this.peopleCollection.Take(indexer + 1).ToArray();
        }

        private void CheckIfPersonIsUnique(Person person)
        {
            if (this.peopleCollection.Any(x => x != null && x.Username == person.Username))
            {
                throw new InvalidOperationException();
            }

            if (this.peopleCollection.Any(x => x != null && x.Id == person.Id))
            {
                throw new InvalidOperationException();
            }
        }
    }
}
