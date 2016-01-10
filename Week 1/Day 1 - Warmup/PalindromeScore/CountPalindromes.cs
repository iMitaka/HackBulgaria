using System;
using System.Linq;

public class CountPalindromes
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(PScore(number));
    }
    public static int PScore(int number)
    {
        if (number.ToString() == new string(number.ToString().Reverse().ToArray()))
        {
            return 1;
        }
        else
        {
            int count = 1;
            while (true)
            {
                string reversedNumber = new string(number.ToString().Reverse().ToArray());
                int result = number + int.Parse(reversedNumber);
                count++;
                number = result;
                if (PScore(number) == 1)
                {
                    return count;
                }
            }
        }
    }
}
