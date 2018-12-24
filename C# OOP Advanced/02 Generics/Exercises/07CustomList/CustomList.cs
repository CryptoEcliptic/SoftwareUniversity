using System;
using System.Collections.Generic;
using System.Text;

namespace _07CustomList
{
    public class CustomList<T> : ICustomList<T> 
        where T : IComparable<T>
    {
        private const int DefaultArraySize = 4;
        public T[] arrayAsList;

        public CustomList()
        {
            this.arrayAsList = new T[DefaultArraySize];
        }

        public int currentPosition { get; private set; }

        public void Add(T element)
        {
            if (currentPosition == arrayAsList.Length)
            {
                ResizeArray();
            }
            arrayAsList[currentPosition] = element;
            currentPosition++;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < currentPosition; i++)
            {
                if (arrayAsList[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public int CountGreaterThan(T element)
        {
            int count = 0;
            for (int i = 0; i < currentPosition; i++)
            {
                if (arrayAsList[i].CompareTo(element) > 0)
                {
                    count++;
                }
            }
            return count;
        }

        public T Max()
        {
            if (this.currentPosition == 0)
            {
                throw new InvalidOperationException();
            }
            T maxElement = arrayAsList[0];
            for (int i = 0; i < currentPosition; i++)
            {
                if (arrayAsList[i].CompareTo(maxElement) > 0)
                {
                    maxElement = arrayAsList[i];
                }
            }
            return maxElement;
        }

        public T Min()
        {
            if (this.currentPosition == 0)
            {
                throw new InvalidOperationException();
            }
            T minElement = arrayAsList[0];
            for (int i = 0; i < currentPosition; i++)
            {
                if (arrayAsList[i].CompareTo(minElement) < 0)
                {
                    minElement = arrayAsList[i];
                }
            }
            return minElement;
        }

        public T Remove(int index)
        {
            if (index < 0 || index > this.currentPosition)
            {
                throw new InvalidOperationException();
            }

            T currentElement = this.arrayAsList[index];
            this.arrayAsList[index] = default(T);
            this.currentPosition--;

            for (int i = index; i < this.currentPosition; i++)
            {
                this.arrayAsList[i] = this.arrayAsList[i + 1];

                if (i != this.currentPosition)
                {
                    this.arrayAsList[i + 1] = default(T);
                }

            }
            
            return currentElement;
        }

        public void Swap(int sourceIndex, int destinationIndex)
        {
            if (destinationIndex < 0 || destinationIndex > this.currentPosition || 
                sourceIndex < 0 || sourceIndex > this.currentPosition)
            {
                throw new InvalidOperationException();
            }
            T temporaryData = this.arrayAsList[sourceIndex];
            this.arrayAsList[sourceIndex] = this.arrayAsList[destinationIndex];
            this.arrayAsList[destinationIndex] = temporaryData;
        }

        private void ResizeArray()
        {
            T[] temporaryArray = new T[currentPosition * 2];

            for (int i = 0; i < arrayAsList.Length; i++)
            {
                temporaryArray[i] = arrayAsList[i];
            }
            arrayAsList = temporaryArray;
        }

        public override string ToString()
        {
            return String.Join("\n", arrayAsList).TrimEnd(); ;
        }
    }
}
