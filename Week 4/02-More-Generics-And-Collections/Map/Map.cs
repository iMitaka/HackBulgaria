using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicArray;

namespace Map
{
    public class Map<T, U>
    {
        private DynamicArray<T> keys;
        private DynamicArray<U> values;
        public Map() 
        {
            this.keys = new DynamicArray<T>();
            this.values = new DynamicArray<U>();
        }
        public void Add(T key, U value)
        {
            if (key.Equals(0))
            {
                throw new Exception("The key cant be zero!");
            }
            if (this.keys.Contains(key))
            {
                throw new ArgumentException("An element with the same key already exists in the Dictionary");
            }

            this.keys.Add(key);
            this.values.Add(value);
        }

        public bool ContainsKey(T key)
        {
            return this.keys.Contains(key);
        }

        public bool ContainsValue(U value)
        {
            return this.values.Contains(value);
        }

        public void Remove(T key)
        {
            if (this.keys.Contains(key))
            {
                var value = this[key];
                this.keys.Remove(key);
                this.values.Remove(value);
            }
            else 
            {
                throw new KeyNotFoundException();
            }
        }

        public void Clear() 
        {
            this.keys.Clear();
            this.values.Clear();
        }

        public U this[T key]
        {
            get 
            {
                if (this.keys.Contains(key))
                {
                    var index = this.keys.IndexOf(key);
                   
                    return this.values[index];
                }
                throw new KeyNotFoundException();
            }
            set 
            {
                if (key.Equals(0))
                {
                    throw new Exception("The key cant be zero!");
                }
                if (this.keys.Contains(key))
                {
                    var index = keys.IndexOf(key);
                    this.values[index] = value;
                }
                else 
                {
                    this.keys.Add(key);
                    this.values.Add(value);
                }
            }
        }
    }
}
