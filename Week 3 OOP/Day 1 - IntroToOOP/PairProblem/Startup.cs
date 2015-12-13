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

            Pair<int, int> pair = new Pair<int, int>(1,2);
            Pair<int, int> anotherPair = new Pair<int, int>(1, 2);
            Console.WriteLine(pair.ToString());
            Console.WriteLine(pair.Equals(anotherPair));
        }
    }
}
