using System;
using System.Linq;

public class WorkWithDigits
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(CountDigits(n));
        Console.WriteLine(SumDigits(n));

    }
    public static uint CountDigits(int number)
    {
        string numberToString = number.ToString();
        return (uint)numberToString.Count();
    }
    public static int SumDigits(int number)
    {
        string numberToString = number.ToString();
        int result = 0;
        for (int i = 0; i < numberToString.Length; i++)
        {
            result += int.Parse(numberToString[i].ToString());
        }
        return result;
    }
}
