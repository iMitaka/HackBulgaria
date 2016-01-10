using System;
using System.Linq;
using System.Collections.Generic;

public class FindBirthdayRanges
{
    public static void Main()
    {
        List<int> birthdays = new List<int>() { 5, 10, 6, 7, 3, 4, 5, 11, 21, 300, 15 };
        List<KeyValuePair<int, int>> ranges = new List<KeyValuePair<int, int>>();
        ranges.Add(new KeyValuePair<int, int>(4, 9));
        ranges.Add(new KeyValuePair<int, int>(6, 7));
        ranges.Add(new KeyValuePair<int, int>(200, 225));
        ranges.Add(new KeyValuePair<int, int>(300, 365));

        //Result:
        var result = BirthdayRanges(birthdays, ranges);

        Console.WriteLine("{" + string.Join(", ", result) + "}");
    }

    public static List<int> BirthdayRanges(List<int> birthdays, List<KeyValuePair<int, int>> ranges)
    {

        List<int> result = new List<int>();
        List<int> sortedBirthdays = new List<int>(birthdays);
        sortedBirthdays.Sort();

        foreach (var kvp in ranges)
        {
            int start = sortedBirthdays.FindIndex(day => day >= kvp.Key && day <= kvp.Value);
            int end = sortedBirthdays.FindLastIndex(day => day >= kvp.Key && day <= kvp.Value);

            if (start < 0)
            {
                result.Add(0);
                continue;
            }

            result.Add((end - start) + 1);
        }

        return result;
    }
}

