using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    public class FilterCollectionApp
    {
        public delegate bool FilterDelegate(int number);

        public static void Main()
        {
            //The filter return collection with integers that are between 10 and 15:
            
            FilterDelegate myDelegate = IsInRange;

            List<int> numbers = new List<int>() { 1, 11, 5, 15, 21, 3, 5, 6, 7, 8, 13, 14 };          

            // Version with Func:

            // Func<int, bool> myFunc = Filter;
            
            numbers = FilterCollection(numbers, myDelegate);

            var result = string.Join(", ", numbers);
            Console.WriteLine(result);
        }

        public static List<int> FilterCollection(List<int> original, FilterDelegate myDelegate)
        {
            for (int i = 0; i < original.Count; i++)
            {
                if (!myDelegate(original.ElementAt(i)))
                {
                    original.Remove(original.ElementAt(i));
                    i--;
                }
            }

            return original;
        }

        public static bool IsInRange(int number)
        {
            if (number >= 10 && number <= 15)
            {
                return true;
            }
            return false;
        }
    }
}
