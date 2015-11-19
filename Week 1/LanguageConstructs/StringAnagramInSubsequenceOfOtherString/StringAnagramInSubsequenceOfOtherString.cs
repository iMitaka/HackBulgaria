using System;
using System.Collections.Generic;
using System.Linq;

public class StringAnagramInSubsequenceOfOtherString
{
    public static void Main()
    {
        //Result:
        Console.WriteLine(HasAnagramOf("bira", "kozariba"));
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