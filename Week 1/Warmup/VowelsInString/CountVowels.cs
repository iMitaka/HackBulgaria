using System;
using System.Linq;

public class CountVowels
{
    public static void Main()
    {
        string someString = Console.ReadLine();
        char[] vowels = "aeiouy".ToArray();
        int count = 0;
        foreach (var element in someString)
        {
            if (vowels.Contains(Char.ToLower(element)))
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }
}
