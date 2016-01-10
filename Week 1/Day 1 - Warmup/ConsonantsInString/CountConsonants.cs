using System;
using System.Linq;

public class CountConsonants
{
    public static void Main()
    {
        string someString = Console.ReadLine();
        char[] consonants = "bcdfghjklmnpqrstvwxz".ToArray();
        int count = 0;
        foreach (var element in someString)
        {
            if (consonants.Contains(Char.ToLower(element)))
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }
}

