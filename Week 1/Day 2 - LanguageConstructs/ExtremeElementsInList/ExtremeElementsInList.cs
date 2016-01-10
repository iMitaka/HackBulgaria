using System;
using System.Linq;
using System.Collections.Generic;

public class ExtremeElementsInList
{
    public static void Main()
    {
        int[] sequence = { 1, 1, 1, 1, 2, 3, 3, 3, 3, 3, 4, 5, 6, 7, 8, 9, 9, 9 };

        //Results:
        Console.WriteLine(Min(sequence));
        Console.WriteLine(Max(sequence));
        Console.WriteLine(NthMin(2, sequence));
        Console.WriteLine(NthMax(2, sequence));
    }

    public static int Min(int[] items)
    {
        List<int> listOfItems = items.ToList();
        listOfItems.Sort();
        return listOfItems[0];
    }
    public static int Max(int[] items)
    {
        List<int> listOfItems = items.ToList();
        listOfItems.Sort();
        int length = listOfItems.Count() - 1;
        return listOfItems[length];
    }
    public static int NthMin(int n, int[] items)
    {
        List<int> listOfItems = items.ToList();
        List<int> distinct = listOfItems.Distinct().ToList();
        distinct.Sort();
        return distinct[n - 1];
    }
    public static int NthMax(int n, int[] items)
    {
        List<int> listOfItems = items.ToList();
        List<int> distinct = listOfItems.Distinct().ToList();
        distinct.Reverse();
        return distinct[n - 1];
    }
}
