using System;
using System.Linq;
using System.Collections.Generic;

public class PrintCharHistogram
{
    public static void Main()
    {
        string someString = Console.ReadLine();
        CharHistogram(someString);

    }
    public static void CharHistogram(string someString)
    {
        Dictionary<char, int> histogram = new Dictionary<char, int>();
        foreach (var element in someString)
        {
            if (histogram.ContainsKey(element))
            {
                histogram[element] += 1;
            }
            else
            {
                histogram.Add(element, 1);
            }
        }
        Console.Write("{ ");
        int count = 0;
        foreach (var item in histogram)
        {
            if (count == histogram.Count() - 1)
            {
                Console.Write("'" + item.Key + "'" + ": " + item.Value + " }");
            }
            else
            {
                Console.Write("'" + item.Key + "'" + ": " + item.Value + ", ");
            }
            count++;
        }
    }
}

