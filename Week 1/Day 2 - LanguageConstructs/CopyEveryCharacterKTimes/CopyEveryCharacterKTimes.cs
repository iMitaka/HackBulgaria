using System;
using System.Text;

public class CopyEveryCharacterKTimes
{
    public static void Main()
    {
        string inputString = Console.ReadLine();
        int copies = int.Parse(Console.ReadLine());

        //Result:

        Console.WriteLine(CopyEveryChar(inputString, copies));
    }

    public static string CopyEveryChar(string someString, int copies)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in someString)
        {
            for (int i = 0; i < copies; i++)
            {
                sb.Append(item);
            }
        }

        return sb.ToString();
    }
}
