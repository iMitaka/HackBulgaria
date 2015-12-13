using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedList<T>
    {
        private Node head;

        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
        }

        public void Add(T value)
        {
            var node = new Node();
            node.Value = value;

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                var current = this.head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = node;
            }
        }

        public void InsertAfter(T key, T value)
        {
            var node = new Node();
            node.Value = value;

            var currentNode = this.head;

            while (!currentNode.Value.Equals(key))
            {
                if (currentNode.Next == null)
                {
                    throw new ArgumentOutOfRangeException(string.Format("No Key found with value: {0}", key));
                }
                currentNode = currentNode.Next;
            }
            node.Next = currentNode.Next;
            currentNode.Next = node;
        }

        public void InsertBefore(T key, T value)
        {
            var node = new Node();
            node.Value = value;

            var currentNode = this.head;
            if (currentNode.Value.Equals(key))
            {
                node.Next = this.head;
                this.head = node;
            }
            else
            {
                while (!currentNode.Next.Value.Equals(key))
                {
                    if (currentNode.Next.Next == null)
                    {
                        throw new ArgumentOutOfRangeException(string.Format("No Key found with value: {0}", key));
                    }
                    currentNode = currentNode.Next;
                }
                node.Next = currentNode.Next;
                currentNode.Next = node;
                currentNode = node;
            }
        }

        public int Count()
        {
            var currentNode = this.head;
            var count = 0;
            while (currentNode != null)
            {
                count++;
                currentNode = currentNode.Next;
            }
            return count;
        }

        public void Remove(T value)
        {
            var currentNode = this.head;
            while (!currentNode.Next.Value.Equals(value))
            {
                currentNode = currentNode.Next;
            }
            currentNode.Next = currentNode.Next.Next;
        }

        public void InsertAt(int index, T value)
        {
            var node = new Node();
            node.Value = value;

            var count = 0;
            var currentNode = this.head;
            if (index > this.Count() || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                node.Next = this.head;
                this.head = node;
            }
            else
            {
                while (count < index - 1)
                {
                    currentNode = currentNode.Next;
                    count++;
                }
                var next = currentNode.Next;
                node.Next = next;
                currentNode.Next = node;
            }
        }

        public void RemoveAt(int index)
        {
            var currentNode = this.head;
            var count = 0;
            if (index >= this.Count() || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                this.head = this.head.Next;
            }
            else
            {
                while (count < index - 1)
                {
                    currentNode = currentNode.Next;
                    count++;
                }
                currentNode.Next = currentNode.Next.Next;
            }
        }

        public void Clear()
        {
            for (int i = this.Count() - 1; i >= 0; i--)
            {
                RemoveAt(i);
            }
        }

        public T this[int index]
        {
            get
            {
                var currentNode = this.head;
                var count = 0;
                while (count <= index - 1)
                {
                    currentNode = currentNode.Next;
                    count++;
                }
                return currentNode.Value;
            }
            set
            {
                var currentNode = this.head;
                var count = 0;
                while (count <= index - 1)
                {
                    currentNode = currentNode.Next;
                    count++;
                }
                currentNode.Value = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }

        }
    }
}
