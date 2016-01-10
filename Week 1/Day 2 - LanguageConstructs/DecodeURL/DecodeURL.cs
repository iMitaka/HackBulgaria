using System;

public class DecodeURL
{
    public static void Main()
    {
        string input = Console.ReadLine();

        //Result:

        Console.WriteLine(DecodeUrl(input));
    }

    public static string DecodeUrl(string input)
    {
        string decode = string.Empty;
        if (input.Contains("%20"))
        {
            decode = input.Replace("%20", " ");
            input = decode;
        }
        if (input.Contains("%3A"))
        {
            decode = input.Replace("%3A", ":");
            input = decode;
        }
        if (input.Contains("%3D"))
        {
            decode = input.Replace("%3D", "?");
            input = decode;
        }
        if (input.Contains("%2F"))
        {
            decode = input.Replace("%2F", "/");
        }

        return decode;
    }
}
