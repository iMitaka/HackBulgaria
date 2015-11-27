using System;
using System.Globalization;

public class PrintConsoleCalendar
{
    public static void Main()
    {
        PrintCalendar(11, 2015, new CultureInfo("en-US"));
    }
    public static void PrintCalendar(int month, int year, CultureInfo culture)
    {
        Calendar myCal = culture.Calendar;
        int daysInMounth = myCal.GetDaysInMonth(year, month);
        Console.WriteLine(culture.DateTimeFormat.MonthNames[month - 1]);
        Console.WriteLine();
        foreach (var day in culture.DateTimeFormat.DayNames)
        {
            Console.Write("{0,10} ", day);
        }
        Console.WriteLine();
        Console.WriteLine();
        for (int i = 1; i <= daysInMounth; i++)
        {
            Console.Write("{0,10} ", i);
            if (i % 7 == 0)
            {
                Console.WriteLine("\n");
            }
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}
