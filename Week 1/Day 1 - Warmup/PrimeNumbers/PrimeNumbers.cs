using System;
using System.Collections.Generic;

public class PrimeNumbers
{
    public static void Main()
    {
        Console.WriteLine(IsPrime(5));
        int n = int.Parse(Console.ReadLine());
        ListFirstPrimes(n);
        Console.WriteLine();
        Console.WriteLine("SieveOfEratosthenes:");
        Console.WriteLine();
        SieveOfEratosthenes(n);
    }

    public static bool IsPrime(int input)
    {
        bool numberIsPrime = true;
        for (int i = 2; i <= Math.Sqrt(input); i++)
        {
            if (input % i == 0)
            {
                numberIsPrime = false;
            }
        }

        return numberIsPrime;
    }

    public static void SieveOfEratosthenes(int number)
    {
        HashSet<int> NoPrime = new HashSet<int>();

        for (int x = 2; x < number; x++)
        {
            for (int y = x * 2; y < number; y = y + x)
            {

                if (!NoPrime.Contains(y))
                {
                    NoPrime.Add(y);
                }

            }

        }

        for (int z = 2; z < number; z++)
        {
            if (!NoPrime.Contains(z))
            {
                Console.WriteLine(z);
            }
        }
    }
    public static void ListFirstPrimes(int number)
    {
        for (int i = 0; i < number; i++)
        {
            if (IsPrime(i))
            {
                Console.WriteLine(i);
            }
        }
    }
}

