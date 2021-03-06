﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _01ListyIterator.Modles
{
    public class ListyIterator<T>
    {
        private List<T> collection;
        private int index = 0;

        public ListyIterator(params T[] inputElements)
        {
            this.collection = new List<T>();
            Create(inputElements);
        }

        public void Create(params T[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                collection.Add(elements[i]);
            }
        }

        public bool Move()
        {
            if (IsInside())
            {
                index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if (IsInside() && collection[index + 1] != null)
            {
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(collection[index]);
        }

        private bool IsInside()
        {
            if (index < 0 || index + 1 > this.collection.Count - 1)
            {
                    return false;
            }
            return true;
        }
    }

}
