using System;

public class PrintJoinedString
{
    public static void Main()
    {
        string separator = ", ";
        string[] strings = { "dog", "cat", "pandaria", "horse" };
        
        //Result:
        string result = JoinStrings(separator, strings);
        
        Console.WriteLine(result);
    }

    public static string JoinStrings(string separator, params string[] strings)
    {
        return string.Join(separator, strings);
    }
}

