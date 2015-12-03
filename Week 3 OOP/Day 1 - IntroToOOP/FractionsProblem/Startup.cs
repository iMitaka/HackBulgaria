using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionsProblem
{
    class Startup
    {
        static void Main(string[] args)
        {
            // *Result if set constructor with denominator = 0

            var nullDenomeratorFraction = new Fraction(1, 0);
            //Console.WriteLine(nullDenomeratorFraction.Denomerator); // - Throw Exeption!

            // *Result if cread fraction with denominator = 1, but next set to 0 in property

            var customFraction = new Fraction(1, 1);
            customFraction.Denomerator = 0;
            //Console.WriteLine(fraction.Denomerator); // - Throw Exeption!

            // *Result .Equals, operator == and != :
            var fraction = new Fraction(1, 1);
            var anotherFraction = new Fraction(1, 1);
            var thirtFraction = new Fraction(2, 2);

            Console.WriteLine(fraction.Equals(anotherFraction));
            Console.WriteLine(fraction.Equals(thirtFraction));
            Console.WriteLine();
            Console.WriteLine(fraction == anotherFraction);
            Console.WriteLine(fraction == thirtFraction);
            Console.WriteLine();
            Console.WriteLine(fraction != anotherFraction);
            Console.WriteLine(fraction != thirtFraction);

            Console.WriteLine();
            // *Result .ToString()
   
            Console.WriteLine(fraction.ToString());
            Console.WriteLine(anotherFraction.ToString());
            Console.WriteLine(thirtFraction.ToString());

            Console.WriteLine();
            // *Result GetHashCode:

            Console.WriteLine(fraction.GetHashCode());
            Console.WriteLine(anotherFraction.GetHashCode());
            Console.WriteLine(thirtFraction.GetHashCode());
        }
    }
}
