using System;
using System.Collections.Generic;
using System.Linq;

public class Anagrams
{
    public static void Main()
    {
        string input = Console.ReadLine();
        string anotherInput = Console.ReadLine();

        Console.WriteLine(IsAnagram(input, anotherInput));

        Console.WriteLine(HasAnagramOf("bira","jivariba"));
    }

    public static bool IsAnagram(string input, string anotherInput)
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

    public static bool HasAnagramOf(string firstString, string secondString)
    {
        var permutationsList = FindPermutations(firstString);
        foreach (var word in permutationsList)
        {
            if (secondString.Contains(word))
            {
                return true;
            }
        }

        return false;
    }

    public static List<string> FindPermutations(string input)
    {
        if (input.Length == 1)
	{
            return new List<string> { input };
	}
        var perms = new List<string>();
        foreach (var c in input)
        {
            var others = input.Remove(input.IndexOf(c), 1);
            perms.AddRange(FindPermutations(others).Select(perm => c + perm));
        }
        return perms;
    }
}
