using System;
using System.Collections.Generic;

public class PrintReversedList
{
    public static void Main()
    {
        List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };

        //Result:
        ReverseList(list);

        Console.WriteLine(string.Join(", ",list));
    }

    public static void ReverseList(List<int> list)
    {
        list.Reverse();
    }
}
