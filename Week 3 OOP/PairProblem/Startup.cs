using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairProblem
{
    class Startup
    {
        static void Main(string[] args)
        {
            object[] pairs = { 1, 2, 3, 4, 5 };
            object[] anotherPairs = { "aa", "bb" };

            var pair = new Pair(pairs);
            var anotherPair = new Pair(pairs);
            Console.WriteLine(pair.ToString());
            Console.WriteLine(pair.Equals(anotherPair));
        }
    }
}
