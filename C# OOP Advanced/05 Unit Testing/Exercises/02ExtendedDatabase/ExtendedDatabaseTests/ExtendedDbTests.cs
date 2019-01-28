using _02ExtendedDatabase;
using NUnit.Framework;
using System;

namespace ExtendedDatabaseTests
{
    [TestFixture]
    public class ExtendedDbTests
    {
        private Person[] initialPeopleArr = new Person[]
            {
                new Person(123, "Gosho"),
                new Person(123456, "Ivan"),
                new Person(007, "Zoran"),
                new Person(125, "Stavri"),
                new Person(978, "Jordan")
            };
        private Person[] repeatedPeopleArr = new Person[]
            {
                new Person(123, "Gosho"),
                new Person(123, "Gosho"),
                new Person(007, "Zoran"),
                new Person(125, "Stavri"),
                new Person(978, "Jordan")
            };
        private Person[] OutOfRangePeopleArr = new Person[]
            {
                new Person(123, "Gosho"),
                new Person(124, "Stavri"),
                new Person(007, "Pet"),
                new Person(008, "Horse"),
                new Person(009, "Alf"),
                new Person(010, "Petkan"),
                new Person(011, "Zorka"),
                new Person(012, "Pijo"),
                new Person(013, "Penda"),
                new Person(014, "Tuhla"),
                new Person(015, "Mara"),
                new Person(016, "Bira"),
                new Person(017, "Joro"),
                new Person(018, "salfetka"),
                new Person(019, "Barko"),
                new Person(020, "Kro"),
                new Person(021, "Lorn")
            };
        private Person[] fullPeopleArr = new Person[]
            {
                new Person(123, "Gosho"),
                new Person(124, "Stavri"),
                new Person(007, "Pet"),
                new Person(008, "Horse"),
                new Person(009, "Alf"),
                new Person(010, "Petkan"),
                new Person(011, "Zorka"),
                new Person(012, "Pijo"),
                new Person(013, "Penda"),
                new Person(014, "Tuhla"),
                new Person(015, "Mara"),
                new Person(016, "Bira"),
                new Person(017, "Joro"),
                new Person(018, "salfetka"),
                new Person(019, "Barko"),
                new Person(020, "Kro"),
            };

        [Test]
        public void CtorShouldSetPeople()
        {
            Database database = new Database(initialPeopleArr);
            Person[] returnedPeople = database.Fetch();
            Assert.That(initialPeopleArr, Is.EqualTo(returnedPeople), "Constructor failed to set input data.");
        }

        [Test]
        public void CtroShouldThrowExceptionIfTwoSamePeople()
        {
            Assert.Throws<InvalidOperationException>(() => new Database(repeatedPeopleArr), "Constructor should" +
                "throw an InvalidOperationException exceprion in case of repeated elements are provided");
        }

        [Test]
        public void CtorShouldThrowExceptionIfInputDataExceedsSixteenElements()
        {
            Assert.Throws<InvalidOperationException>(() => new Database(OutOfRangePeopleArr), "Constructor should" +
                "throw an InvalidOperation Exception if input elements are more than sixteen.");
        }

        [Test]
        public void AddMethodShouldAddPeopleIfIndexIsValid()
        {
            //Arrange
            Database database = new Database(initialPeopleArr);
            Person addedPerson = new Person(12, "Dorcheto");
            database.Add(addedPerson);

            //Act
            Person[] returnPeople = database.Fetch();
            Person expectedPerson = returnPeople[returnPeople.Length - 1];

            //Assert
            Assert.That(addedPerson, Is.EqualTo(expectedPerson), "OOPS, Add method does not add elements");
        }

        [Test]
        public void AddFunctionShouldThrowExceptionIfCapacityIsFull()
        {
            Database database = new Database(fullPeopleArr);

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(357, "Petrancheto")), 
                "Exception should be thrown if the array capacity is exceeded.");
        }

        [Test]
        public void AddMethodShouldThrowExceprionIfAddingExistingUsername()
        {
            Database database = new Database(initialPeopleArr);
            Person existingPersonUsername = new Person(0889, "Gosho");

            Assert.Throws<InvalidOperationException>(() => database.Add(existingPersonUsername),
                "Exception should be thrown if provided username exists in the database.");
        }

        [Test]
        public void AddMethodShouldThrowExceprionIfAddingExistingId()
        {
            Database database = new Database(initialPeopleArr);
            Person existingPersonId = new Person(123456, "Svetulka");

            Assert.Throws<InvalidOperationException>(() => database.Add(existingPersonId),
                "Exception should be thrown if provided Id exists in the database.");
        }

        [Test]
        public void RemoveFunctionShoultThrowExceptionIfArrayIsEmpty()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove(), 
                "Exception should be thrown if try to remove element from empty database.");
        }

        [Test]
        public void RemoveFunctionShouldRemoveElement()
        {
            var database = new Database(initialPeopleArr);
            int expectedLength = initialPeopleArr.Length - 1;

            database.Remove();
            Person[] peopleLeft = database.Fetch();
            int actualLength = peopleLeft.Length;

            Assert.That(expectedLength, Is.EqualTo(actualLength), "Element not successfully removed.");
        }

        [Test]
        public void MethodFindByUsernameThrowsExceptionIfParameterIsNull()
        {
            var database = new Database(initialPeopleArr);

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null), 
                "Exception should be thrown if provided parameter is null");
        }

        [Test]
        public void MethodFindByUsernameThrowsExceptionIfUsernameNotExistInTheDb()
        {
            var database = new Database(initialPeopleArr);

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Veronika"), 
                "Exception should be thrown if provided username does not exist in the database.");
        }

        [Test]
        public void MethodFindByUsernameReturnsPersonWithExistingUsername()
        {
            var database = new Database(initialPeopleArr);
            string nameToFind = "Stavri";
            Person returnedPerson = database.FindByUsername(nameToFind);

            Assert.That(returnedPerson.Username, Is.EqualTo(nameToFind), "Method does not return searched" +
                " person");
        }

        [Test]
        public void FindByIdThrowsExceptionIfParameterIsNegative()
        {
            var database = new Database(initialPeopleArr);

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-2), "Exception should be " +
                "thrown if provided parameter is negative");
        }

        [Test]
        public void MethodFindByIdThrowsExceptionIfIdNotExistInTheDb()
        {
            var database = new Database(initialPeopleArr);
            long nonExistingId = 00008564;

            Assert.Throws<InvalidOperationException>(() => database.FindById(nonExistingId), "Exceptiion" +
                " should be thrown if provided parameter does not exist in the database.");
        }

        [Test]
        public void MethodFindByIdReturnsPersonWithExistingId()
        {
            var database = new Database(initialPeopleArr);
            long idToFind = 007;
            Person returnedPerson = database.FindById(idToFind);

            Assert.That(returnedPerson.Id, Is.EqualTo(idToFind));
        }

        [Test]
        public void FetchFunctionShouldReturnCorrectly()
        {
            var database = new Database(initialPeopleArr);

            Person[] returnedPeople = database.Fetch();

            Assert.That(returnedPeople, Is.EqualTo(initialPeopleArr));
        }

        [Test]
        public void FetchFunctionReturnCorrectlyAfterRemovalOfElements()
        {
            var database = new Database(initialPeopleArr);
            database.Remove();

            Person[] returnedPeople = database.Fetch();
            Person[] expectedPeople = new Person[]
            {
                new Person(123, "Gosho"),
                new Person(123456, "Ivan"),
                new Person(007, "Zoran"),
                new Person(125, "Stavri")
            };

            Assert.That(returnedPeople.Length.Equals(expectedPeople.Length),
                "Returned elements cound does not match with expected.");
        }
    }
}
