﻿using System;
using System.Collections.Generic;

public class FactorialGenerator
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        
        //Result:
        var result = GenerateFactorials(number);

        foreach (var factorial in result)
        {
            Console.Write(factorial + " ");
        }
        Console.WriteLine();
    }

    public static IEnumerable<int> GenerateFactorials(int n)
    {
        int result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
            yield return result;
        }
    }
}
