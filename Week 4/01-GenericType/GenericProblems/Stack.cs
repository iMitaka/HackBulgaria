using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericProblems
{
    public class Stack<T>
    {
        private List<T> innerCollection = new List<T>();

        public T Peek()
        {
           return this.innerCollection.LastOrDefault();
        }

        public T Pop() 
        {
            var item = this.innerCollection.LastOrDefault();
            this.innerCollection.Remove(item);
            return item;
        }

        public void Push(T item) 
        {
            var length = this.innerCollection.Count();
            this.innerCollection.Insert(length - 1, item);
        }

        public void Clear() 
        {
            this.innerCollection.Clear();
        }

        public bool Contains(T item) 
        {
            return this.innerCollection.Contains(item);
        }
    }
}
