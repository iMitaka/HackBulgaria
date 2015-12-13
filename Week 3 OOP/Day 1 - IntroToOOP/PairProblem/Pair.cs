using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairProblem
{
    public class Pair<T1, T2>
    {
        private T1 firstMember;
        private T2 secondMember;

        public Pair(T1 firstMember, T2 secondMember)
        {
            this.firstMember = firstMember;
            this.secondMember = secondMember;
        }

        public T1 FirstPair
        {
            get
            {
                return this.firstMember;
            }
        }

        public T2 SecondPair
        {
            get
            {
                return this.secondMember;
            }
        }

        public override string ToString()
        {
            return string.Format("First Member: {0}, Second Member: {1}", this.firstMember, this.secondMember);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Pair<T1,T2>))
            {
                throw new FormatException("The other object must be a Pair object");
            }
            var otherPair = obj as Pair<T1, T2>;
            return this.FirstPair.Equals(otherPair.FirstPair) && this.SecondPair.Equals(otherPair.SecondPair);
        }

        public static bool operator ==(Pair<T1, T2> a, Pair<T1, T2> b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Pair<T1, T2> a, Pair<T1, T2> b)
        {
            return !a.Equals(b);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + this.FirstPair.GetHashCode();
                hash = hash * 23 + this.SecondPair.GetHashCode();
                return hash;
            }
        }
    }
}
