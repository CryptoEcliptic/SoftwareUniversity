using System;
using System.Collections;
using System.Collections.Generic;

namespace _03Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private Node<T> node;

        public CustomStack()
        {
            this.node = null;
        }

        private class Node<T>
        {
            public Node(T element)
            {
                this.Element = element;
                this.Prev = null;
            }

            public T Element { get; set; }
            public Node<T> Prev { get; set; }
        }

        public void Push(T element)
        {
            Node<T> currentNode = new Node<T>(element);

            if (this.node == null)
            {
                this.node = currentNode;
            }
            else
            {
                Node<T> saveCurrentTop = this.node;
                this.node = currentNode;
                this.node.Prev = saveCurrentTop;
            }
        }

        public T Pop()
        {
            if (this.node != null)
            {
                T returnValue = this.node.Element;
                Node<T> current = this.node;
                this.node = this.node.Prev;
                current = null;
                return returnValue;
            }

            throw new InvalidOperationException("No elements");
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this.node;

            while (current != null)
            {
                yield return current.Element;

                current = current.Prev;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
