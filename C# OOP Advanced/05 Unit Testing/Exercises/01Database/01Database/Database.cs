using System;
using System.Linq;

namespace _01Database
{
    public class Database
    {
        private const int capacity = 16;
        
        private int[] numbersArr;
        private int indexer;


        public Database()
        {
            this.numbersArr = new int[capacity];
            indexer = -1;
        }
        public Database(int[] inputNumbers)
        {
            this.numbersArr = new int[capacity];
            if (inputNumbers.Length > capacity)
            {
                throw new InvalidOperationException();
            }
            indexer = inputNumbers.Length - 1;
            for (int i = 0; i < inputNumbers.Length; i++)
            {
                numbersArr[i] = inputNumbers[i];
            }
        }

        public void Add(int number)
        {
            if (indexer > numbersArr.Length - 2)
            {
                throw new InvalidOperationException();
            }
         
            this.numbersArr[++indexer] = number;
        }

        public int Remove()
        {
            if (indexer == -1)
            {
                throw new InvalidOperationException();
            }
            int returnElement = this.numbersArr[indexer];
            this.numbersArr[indexer] = 0;
            indexer--;
            return returnElement;
        }

        public int[] Fetch()
        {
            return this.numbersArr.Take(indexer + 1).ToArray();
        }
    }
}
