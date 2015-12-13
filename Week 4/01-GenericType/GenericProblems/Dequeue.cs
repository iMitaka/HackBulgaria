using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericProblems
{
    public class Dequeue<T>
    {
        private List<T> innerCollection = new List<T>();

        public void Clear() 
        {
            this.innerCollection.Clear();
        }

        public bool Contains(T item)
        {
            return this.innerCollection.Contains(item);
        }

        public T RemoveFromFront() 
        {
            var item = this.innerCollection.LastOrDefault();
            this.innerCollection.Remove(item);
            return item;
        }

        public T RemoveFromEnd() 
        {
            var item = this.innerCollection.FirstOrDefault();
            this.innerCollection.Remove(item);
            return item;
        }

        public void AddToFront(T item) 
        {
            this.innerCollection.Add(item);          
        }

        public void AddToEnd(T item) 
        {
            var length = this.innerCollection.Count();
            this.innerCollection.Insert(length - 1, item);
        }

        public T PeekFromFront() 
        {
            return this.innerCollection.LastOrDefault();
        }

        public T PeekFromEnd() 
        {
            return this.innerCollection.FirstOrDefault();
        }
    }
}
