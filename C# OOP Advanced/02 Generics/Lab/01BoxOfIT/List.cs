using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        public List<T> collection;
   
        public Box()
        {
            this.collection = new List<T>();
        }

        public void Add(T element)
        {
            collection.Add(element);
        }

        public T Remove()
        {
            var lastElement = collection.LastOrDefault();
            this.collection.RemoveAt(this.collection.Count - 1);
            return lastElement;
        }

        public int Count => this.collection.Count();

    } 
}

