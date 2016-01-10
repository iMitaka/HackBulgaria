using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregates
{
    public class AggregatesApp
    {
        // public delegate void SecondAggregationDelegate(List<int> numbers); 

        public delegate decimal AggregationDelegate(List<int> numbers); 

        public static void Main()
        {
            List<int> numbers = new List<int>() { 55, 11, 5, 15, 21, 3, 5, 6, 7, 8, 13, 14 };

            AggregationDelegate myDelegate = CalculateAvarage;

            // Modern style of delegate implementation:
            // Func<List<int>, decimal> myFunc = CalculateAvarage;

            // Test of multicast void delegates
            //
            // SecondAggregationDelegate mySecondDelegate = Min;
            // mySecondDelegate += Max;
            // mySecondDelegate += Sum;
            // mySecondDelegate += Average;

            // mySecondDelegate(numbers);

            Console.WriteLine("Avarage : {0:F2}", AggregateCollection(numbers, myDelegate));

        }

        public static decimal AggregateCollection(List<int> original, AggregationDelegate aggregate) 
        {
            return aggregate(original);
        }

        public static void Min(List<int> numbers) 
        {
            int minNumber = numbers.ElementAt(0);
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers.ElementAt(i) < minNumber)
                {
                    minNumber = numbers.ElementAt(i);
                }
            }
            Console.WriteLine("Min Number: " + minNumber);
        }

        public static void Max(List<int> numbers) 
        {
            int maxNumber = numbers.ElementAt(0);
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers.ElementAt(i) > maxNumber)
                {
                    maxNumber = numbers.ElementAt(i);
                }
            }
            Console.WriteLine("Max Number: " + maxNumber);
        }

        public static void Sum(List<int> numbers) 
        {
            var sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            Console.WriteLine("Sum Of Numbers: " + sum);
        }

        public static void Average(List<int> numbers) 
        {
            double sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            Console.WriteLine("Numbers Average: {0:F2}",sum / numbers.Count);
        }

        public static decimal CalculateAvarage(List<int> numbers)
        {
            decimal sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            return sum / numbers.Count;
        }
    }
}
