using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionsSolution
{
    public class TestAlgorithmsProgramMain
    {
        public static void Main()
        {
            Console.WriteLine("*LastDigitComparer + BubbleSort: ");
            Console.WriteLine();

            var array = new List<int>() { 213, 412, 141, 445, 550 };
            var sortedArray = array.BubbleSort(new LastDigitComparer());

            foreach (var item in sortedArray)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("*ReverseComparer<T> + StringLengthComparer + SelectionSort: ");
            Console.WriteLine();

            var strings = new List<string>() { "sss", "cccc", null, "aaaaa", "bbbssss", "A" };
            var stringsArray = strings.SelectionSort(new ReverseComparer<string>(new StringLengthComparer()));
            strings.Add("o");
            foreach (var item in stringsArray)
            {
                if (item == null)
                {
                    Console.WriteLine("\"null\"");
                }
                else
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine();

            Console.WriteLine("*OddEvenComparer + Quicksort: ");
            Console.WriteLine();

            var oddOrEven = new List<int?>() { 5, null, 2, 7, 8, 12, 10, 9, 8 };
            var oddOrEvenSorted = oddOrEven.Quicksort(new OddEvenComparer());

            foreach (var item in oddOrEvenSorted)
            {
                if (item == null)
                {
                    Console.WriteLine("\"null\"");
                }
                else
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine();
        }
    }
}
