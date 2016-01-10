using System;
using System.Numerics;

public class PrintFactorial
{
    public static void Main()
    {
        int input = int.Parse(Console.ReadLine());
        //BigInteger result = 1;
        //for (int i = 1; i <= input; i++)
        //{
        //    result *= i;
        //}
        //Console.WriteLine(result);

        Console.WriteLine(Recursion(input));
    }

    public static BigInteger Recursion(int number)
    {

        if (number == 0)
        {
            return 1;
        }
        return number * Recursion(number - 1);
    }
}

