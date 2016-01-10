using System;
using System.Linq;

public class StringsAnagrams
{
    public static void Main()
    {
        string input = Console.ReadLine();
        string anotherInput = Console.ReadLine();

        //Result:
        Console.WriteLine(Anagram(input, anotherInput));
    }

    public static bool Anagram(string input, string anotherInput)
    {
        char[] inputToArrey = input.ToArray();
        bool anagram = true;
        foreach (var item in anotherInput)
        {
            if (!inputToArrey.Contains(item))
            {
                anagram = false;
            }
        }
        return anagram;
    }
}
