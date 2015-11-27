using System;

public class CountUnfortunateFridays
{
    public static void Main()
    {
        int startYear = 2015;
        int endYear = 2016;

        //Result:
        var count = UnfortunateFridays(startYear, endYear);
        Console.WriteLine(count);
    }

    public static int UnfortunateFridays(int startYear, int endYear)
    {
        DateTime from = new DateTime(startYear, 1, 1);
        DateTime to = new DateTime(endYear, 1, 1);
        var count = 0;
        while (true)
        {
            if (from.Day == to.Day && from.Month == to.Month && from.Year == to.Year)
            {
                break;
            }
            from = from.AddDays(1);
            if (from.DayOfWeek.ToString() == "Friday" && from.Day == 13)
            {
                //Console.WriteLine(from.DayOfWeek + " " + from.Day + " " + from.Month + " " + from.Year);
                count++;
            }
        }
        return count;
    }
}
