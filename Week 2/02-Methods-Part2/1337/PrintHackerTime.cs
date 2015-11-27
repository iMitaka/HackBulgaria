using System;

public class PrintHackerTime
{
    public static void Main()
    {
        HackerTime();
    }
    public static void HackerTime()
    {
        var hackerTime = new DateTime(DateTime.Now.Year, 12, 23, 13, 37, 00);
        var now = DateTime.Now;
        if (hackerTime >= now)
        {
            var result = hackerTime - now;
            Console.WriteLine("{0:D2}:{1:D2}:{2:D2}", result.Days, result.Hours, result.Minutes);
        }
        else
        {
            hackerTime = hackerTime.AddYears(1);
            Console.WriteLine(hackerTime - now);
        }
    }
}