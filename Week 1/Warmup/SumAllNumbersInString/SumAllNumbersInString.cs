using System;
using System.Collections.Generic;
using System.Text;

public class SumAllNumbersInString
{
    public static void Main()
    {
        string input = Console.ReadLine() + "a";
        StringBuilder sb = new StringBuilder();
        List<int> listOfNumbers = new List<int>();
        foreach (var item in input)
        {
            if (item >= '0' && item <= '9')
            {
                sb.Append(item);
            }
            else
            {
                if (sb.Length > 0)
                {
                    listOfNumbers.Add(int.Parse(sb.ToString()));
                }

                sb.Clear();
            }
        }
        int result = 0;
        foreach (var item in listOfNumbers)
        {
            result += item;
        }
        Console.WriteLine(result);
    }
}

