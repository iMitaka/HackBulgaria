using System;
using System.Collections.Generic;
using System.Text;

public class NumbersAndLists
{
    public static void Main()
    {
        int inputNumber = int.Parse(Console.ReadLine());

        //Result of NumberToList:

        foreach (var digit in NumberToList(inputNumber))
        {
            Console.Write(digit + ", ");
        }
        Console.WriteLine();

        //Result of ListToNumber:

        int result = ListToNumber(NumberToList(inputNumber));
        Console.WriteLine(result);
    }

    public static List<int> NumberToList(int number)
    {
        string numberToString = number.ToString();
        List<int> listOfNumbers = new List<int>();
        foreach (var digit in numberToString)
        {
            listOfNumbers.Add(int.Parse(digit.ToString()));
        }

        return listOfNumbers;
    }

    public static int ListToNumber(List<int> listOfNumbers)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var digit in listOfNumbers)
        {
            sb.Append(digit);
        }

        return int.Parse(sb.ToString());
    }
}
