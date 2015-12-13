using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    public class DynamicArray<T> : IEnumerable
    {
        private int size;
        private T[] arrey;

        public DynamicArray()
        {
            this.size = 10;
            this.arrey = new T[this.size];      
        }

        public DynamicArray(int size)
        {
            this.size = size;
            this.arrey = new T[this.size];
        }

        public int Capacity
        {
            get
            {
                return this.size;
            }
        }

        public int Count
        {
            get
            {
                int count = 0;
                int forbidden = 0;
                foreach (var item in this.arrey)
                {
                    if (item == null || forbidden.Equals(item))
                    {
                        break;
                    }
                    count++;
                }
                return count;
            }
        }

        public bool Contains(T value)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.arrey[i].Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.arrey[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Add(T value)
        {
            if (this.Count > this.Capacity - 2)
            {
                if (this.size < 2048)
                {
                    this.size *= 2;
                }
                else
                {
                    this.size += 256;
                }
            }
            var arrey = new T[this.size];
            for (int i = 0; i < this.Count; i++)
            {
                arrey[i] = this.arrey[i];
            }
            arrey[this.Count] = value;
            this.arrey = arrey;
        }

        public void InsertAt(int index, T value) 
        {
            if (index > this.Count)
            {
                throw new IndexOutOfRangeException();
            }
            var arrey = this.arrey.ToList();
            arrey.Insert(index, value);
            this.arrey = arrey.ToArray();
        }

        public void Remove(T value) 
        {
            var arrey = this.arrey.ToList();
            arrey.Remove(value);
            this.arrey = arrey.ToArray();
            if (this.Count < this.Capacity / 3)
            {
                this.size /= 2;
                var arr = new T[this.size];
                for (int i = 0; i < this.Count; i++)
                {
                    arr[i] = this.arrey[i];
                }
                this.arrey = arr;
            }            
        }

        public void RemoveAt(int index) 
        {
            var arreyList = this.arrey.ToList();
            for (int i = 0; i < this.Count; i++)
            {
                if (i == index)
                {
                    arreyList.Remove(arreyList[i]);
                }
            }
            this.arrey = arreyList.ToArray();
            if (this.Count < this.Capacity / 3)
            {
                this.size /= 2;
                var arr = new T[this.size];
                for (int i = 0; i < this.Count; i++)
                {
                    arr[i] = this.arrey[i];
                }
                this.arrey = arr;
            }            
        }

        public void Clear() 
        {
            var arreyList = this.arrey.ToList();
            arreyList.Clear();
            this.arrey = arreyList.ToArray();
        }

        public T this[int index] 
        {
            get 
            {
                if (index > this.Count - 1)
                {
                    throw new IndexOutOfRangeException();
                }
                return this.arrey[index];
            }
            set 
            {
                if (index > this.Count - 1)
                {
                    throw new IndexOutOfRangeException();
                }
                this.arrey[index] = value;
            }
        }

        public T[] ToArray() 
        {
            var arrey = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                arrey[i] = this.arrey[i];
            }
            return arrey;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.arrey[i];
            }
        }
    }
}
