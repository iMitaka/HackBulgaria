using System;
using System.Linq;
using System.Text;

public class PrintReversedString
{
    public static void Main()
    {
        string inputString = Console.ReadLine();

        //Result:

        Console.WriteLine(ReverseMe(inputString));
    }

    public static string ReverseMe(string original)
    {
        var reversed = original.ToList();
        reversed.Reverse();
        StringBuilder sb = new StringBuilder();
        foreach (var item in reversed)
        {
            sb.Append(item);
        }

        return sb.ToString();
    }
}
