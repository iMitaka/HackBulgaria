using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairProblem
{
    public class Pair
    {
        public Pair(object[] pairs) 
        {
            this.FirstPair = pairs[0];
            this.SecondPair = pairs[1];
        }

        public object FirstPair { get; private set; }

        public object SecondPair { get; private set; }

        public override string ToString()
        {
            return base.ToString() + "(object[])";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Pair))
            {
                throw new FormatException("The other object must be a Pair object");
            }
            var otherPair = obj as Pair;
            return this.FirstPair == otherPair.FirstPair && this.SecondPair == otherPair.SecondPair;
        }

        public static bool operator ==(Pair a, Pair b) 
        {
            return a.Equals(b);
        }
        public static bool operator !=(Pair a, Pair b)
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
