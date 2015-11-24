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
        Console.WriteLine("{ " + string.Join(", ", histogram.Select(x => "'" + x.Key + "'" + ": " + x.Value).ToArray()) + " }");
    }
}

