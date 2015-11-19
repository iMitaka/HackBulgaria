using System;
using System.Linq;

public class IntegerPalindomes
{
    public static void Main()
    {
        //Test with 120
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(IsIntPalindrome(number));
        GetLargestPalindrome(number);
        GetSmallerPalindrome(number);

    }

    public static bool IsIntPalindrome(int number)
    {
        if (number.ToString() == new string(number.ToString().Reverse().ToArray()))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void GetLargestPalindrome(int number)
    {
        int nextNumber = number + 1;
        if (nextNumber.ToString() == new string(nextNumber.ToString().Reverse().ToArray()))
        {
            Console.WriteLine(nextNumber);
        }
        else
        {
            GetLargestPalindrome(number + 1);
        }
    }

    public static void GetSmallerPalindrome(int number)
    {
        int nextNumber = number - 1;
        if (nextNumber.ToString() == new string(nextNumber.ToString().Reverse().ToArray()))
        {
            Console.WriteLine(nextNumber);
        }
        else
        {
            GetSmallerPalindrome(number - 1);
        }
    }
}
