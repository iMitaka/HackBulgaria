using System;
using System.Linq;

public class HackNumbers
{
    static void Main()
    {
        Console.WriteLine(IsHack(8032));

        NextHack(8031);
    }
    public static bool IsHack(int number)
    {
        string binary = Convert.ToString(number, 2);
        int count = 0;
        foreach (var digit in binary)
        {
            if (digit == '1')
            {
                count++;
            }
        }
        if (count % 2 != 0 && (binary == new string(binary.Reverse().ToArray())))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static void NextHack(int number)
    {
        if (IsHack(number + 1))
        {
            Console.WriteLine(number + 1);
        }
        else
        {
            NextHack(number + 1);
        }
    }
}
