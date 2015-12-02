using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionsProblem
{
    public class Fraction
    {
        private int numerator;
        private int denomerator;

        public Fraction(int numerator, int denomerator)
        {
            if (denomerator == 0)
            {
                throw new ArgumentException("Denominator cannot be 0");
            }

            this.numerator = numerator;
            this.denomerator = denomerator;
        }

        public int Numerator { get; set; }

        public int Denomerator
        {
            get
            {
                return this.denomerator;
            }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Denominator cannot be 0");
                }
            }
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", this.numerator, this.denomerator);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Fraction))
            {
                throw new FormatException("The object must be Fraction type!");
            }
            var newFraction = obj as Fraction;
            return this.denomerator == newFraction.denomerator && this.numerator == newFraction.numerator;
        }

        public static bool operator ==(Fraction first, Fraction second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Fraction first, Fraction second)
        {
            return !(first.Equals(second));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + this.denomerator.GetHashCode();
                hash = hash * 23 + this.numerator.GetHashCode();
                return hash;
            }
        }
    }
}
