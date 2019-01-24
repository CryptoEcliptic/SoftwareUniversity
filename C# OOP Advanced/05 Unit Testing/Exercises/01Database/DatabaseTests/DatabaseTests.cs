using _01Database;
using NUnit.Framework;
using System;
using System.Linq;

namespace DatabaseTests
{
    public class DatabaseTests
    {
        int[] initialInput = new int[] { 1, 2, 3, 4, 5 };
        int[] largeInitialArray = Enumerable.Range(1, 17).ToArray();
        int[] fullInitialArray = Enumerable.Range(1, 16).ToArray();


        [Test]
        public void ConstructorShouldAcceptCertainNumbers()
        {
            var database = new Database(initialInput);

            var actual = database.Fetch();

            Assert.That(actual, Is.EqualTo(initialInput));
        }

        [Test]
        public void CtorShouldThrowsExceptionIfInputCountMoreThanSixteen()
        {
            Assert.Throws<InvalidOperationException>(() => new Database(largeInitialArray));
        }

        [Test]
        public void ShouldAddNumbersIfIndexIsValid()
        {
            int numberToAdd = 6;
            Database database = new Database();

            database.Add(numberToAdd);
            int[] returnValues = database.Fetch();

            Assert.That(returnValues[0].Equals(numberToAdd));
        }

        [Test]
        public void AddFunctionShouldThrowExceptionIfCapacityIsFull()
        {
            var database = new Database(fullInitialArray);
            
            Assert.Throws<InvalidOperationException>(() => database.Add(1));
        }

        [Test]
        public void RemoveFunctionShoultThrowExceptionIfArrayIsEmpty()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void RemoveFunctionShouldRemoveElement()
        {
            var database = new Database(fullInitialArray);

            int removeElement = database.Remove();
            int expectedElement = 16;

            Assert.That(removeElement, Is.EqualTo(expectedElement));
        }

        [Test]
        public void FetchFunctionShouldReturnCorrectElements()
        {
            var database = new Database(fullInitialArray);

            int[] returnedElements = database.Fetch();

            Assert.That(returnedElements, Is.EqualTo(fullInitialArray));
        }

        [Test]
        public void FetchFunctionReturnCorrectElementdAfterRemovedElements()
        {
            var database = new Database(fullInitialArray);
            database.Remove();

            int[] returnedElements = database.Fetch();
            int[] expectedOutput = Enumerable.Range(1, 15).ToArray();

            Assert.That(returnedElements, Is.EqualTo(expectedOutput));
        }
    }
}
