using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoGame
{
    public class Combination<T, U>
    {
        private List<T> firstGroup = new List<T>();
        private List<U> secondGroup = new List<U>();

        public Combination(T num1, T num2, T num3, U text1, U text2, U text3)
        {
            firstGroup.Add(num1);
            firstGroup.Add(num2);
            firstGroup.Add(num3);
            secondGroup.Add(text1);
            secondGroup.Add(text2);
            secondGroup.Add(text3);
        }

        public List<T> FirstGroup
        {
            get
            {
                return this.firstGroup;
            }
        }

        public List<U> SecondGropu 
        {
            get 
            {
                return this.secondGroup;
            }
        }

        public override bool Equals(object obj)
        {
            var combination = obj as Combination<T,U>;
            foreach (var item in firstGroup)
            {
                if (!combination.firstGroup.Contains(item))
                {
                    return false;
                }
            }

            foreach (var item in secondGroup)
            {
                if (!combination.secondGroup.Contains(item))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
