using CustomLinkedList;
using NUnit.Framework;
using System;

namespace CustomLinkedListTests
{

    [TestFixture]
    public class LinkedListTests
    {
        private const int initialCount = 0;

        [Test]
        public void CtorShouldSetCountToZero()
        {
            DynamicList<int> list = new DynamicList<int>();

            Assert.That(list.Count, Is.EqualTo(initialCount), "Ctor did not set the count to zero");
        }

        [Test]
        public void IndexOperatorShouldReturnValue()
        {
            DynamicList<int> list = new DynamicList<int>();

            list.Add(100);//Adds 100 to zero index
            int element = list[0]; //Takes the value from zero index

            Assert.That(element, Is.EqualTo(100), "Index did not return correct value");
        }

        [Test]
        public void IndexOperatorShouldSetValue()
        {
            DynamicList<int> list = new DynamicList<int>();

            list.Add(100);//Add 100 to zero index
            list[0] = 55; //Change the value at zero index from 100 to 55

            Assert.That(list[0], Is.EqualTo(55), "Index was not able to set new value");
        }


        [Test]
        [TestCase(-1)]
        [TestCase(int.MaxValue)]
        [TestCase(100)]
        public void IndexOperatorShouldThrowArgumentOutOfRangeExceptionIfGetInvalidIndex
            (int index)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }

            int value = 1;
            Assert.Throws<ArgumentOutOfRangeException>(() =>  value = list[index] , "Exception " +
                "should be thrown if provided index is invalid");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(int.MaxValue)]
        [TestCase(100)]
        public void IndexOperatorShouldThrowArgumentOutOfRangeExceptionIfSetInvalidIndex
            (int index)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }

            int valueToAccept = 5;

            Assert.Throws<ArgumentOutOfRangeException>(() =>list[index] = valueToAccept, "Exception " +
                "should be thrown if provided index is invalid");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(int.MaxValue)]
        [TestCase(100)]
        public void RemoveAtFunctionShouldThrowsExceptionIfProvidedIndexIsInvalid(int index)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(index), "Exception " +
                "should be thrown if provided index is invalid");
        }

        [Test]
        public void RemoveAtFunctionShouldRemomveElement()
        {
            DynamicList<int> list = new DynamicList<int>();
            int controlValue = 5;
            list.Add(controlValue);
            int returnedElement = list.RemoveAt(0);

            Assert.That(returnedElement, Is.EqualTo(controlValue), "List should be able to remove element at " +
                "certain valid index");

            Assert.That(list.Count, Is.EqualTo(0), $"List count should be zero, " +
                $"but it was {list.Count}");
        }

        [Test]
        public void RemoveFunctionShouldReturtElementIndex()
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 1; i <= 100; i++)
            {
                list.Add(i);
            }

            int itemToRemove = 5;
            int expectedReturnIndex = 4;
            int actualIndex = list.Remove(itemToRemove);

            Assert.That(actualIndex, Is.EqualTo(expectedReturnIndex), $"Returned index was incorect." +
                $"Should be {expectedReturnIndex}, but it was{actualIndex}");
        }

        [Test]
        public void RemoveFunctionShouldReturnMinusOneIfNoSuchElementInCollection()
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 1; i <= 15; i++)
            {
                list.Add(i);
            }

            int actualReturnIndex = list.Remove(20);
            int expectedIndex = -1;

            Assert.That(actualReturnIndex, Is.EqualTo(expectedIndex), $"Returned index" +
                $" should be {expectedIndex}, but it was {actualReturnIndex}");
        }

        [Test]
        public void RemoveFunctionShouldRemoveExistingElement()
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 1; i <= 15; i++)
            {
                list.Add(i);
            }

            int expectedCount = list.Count - 1;
            list.Remove(15);

            Assert.That(list.Count, Is.EqualTo(expectedCount), $"List count should be {expectedCount}, " +
                $"but it was {list.Count}");
        }

        [Test]
        public void IndexOfCommandShouldReturnMinusOneIfNoSuchElementInCollection()
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 1; i <= 15; i++)
            {
                list.Add(i);
            }

            int actualReturnIndex = list.IndexOf(20);
            int expectedIndex = -1;

            Assert.That(actualReturnIndex, Is.EqualTo(expectedIndex), $"Returned index" +
                $" should be {expectedIndex}, but it was {actualReturnIndex}");
        }

        [Test]
        public void ContainsMethodShouldReturnTrueIfElementFound()
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 1; i <= 15; i++)
            {
                list.Add(i);
            }

            bool actualReturn = list.Contains(4);
            bool expectedReturn = true;

            Assert.That(actualReturn, Is.EqualTo(expectedReturn), $"Кофти! Expected result " +
                $"should be true, but it was false");
        }
    }
}
