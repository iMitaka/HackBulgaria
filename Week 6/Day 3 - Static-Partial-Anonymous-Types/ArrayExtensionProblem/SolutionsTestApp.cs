using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExtensionProblem
{
    public class SolutionsTestApp
    {
        public static void Main()
        {
            List<int> firstList = new List<int>() { 1, 2, 3, 4, 5 };
            List<int> secondList = new List<int>() { 3, 4, 5, 6, 7 };

            var newList = ArrayExtension<int>.Union(firstList, secondList);
            // var newList = ArrayExtension<int>.Intersect(firstList, secondList);
            // var newList = ArrayExtension<int>.UnionAll(firstList, secondList);

            foreach (var item in newList)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            Console.WriteLine(ArrayExtension<int>.GetReplacingValue());

            List<string> stringList = new List<string>() { "pesho", "ivan", "mitko", "ala", "bala" };
            Console.WriteLine(ArrayExtension<int>.Join(stringList));
        }
    }
}
