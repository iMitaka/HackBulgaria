using System;
using System.Globalization;

public class PrintConsoleCalendar
{
    public static void Main()
    {
        PrintCalendar(11, 2015, new CultureInfo("bg-BG"));
        Console.WriteLine();
    }

    public static void PrintCalendar(int month, int year, CultureInfo culture)
    {
        int daysInMonth = culture.Calendar.GetDaysInMonth(year, month);
        string[,] calendarMatrix = new string[6, 7];
        int nullDaysCount = 0;
        int currentDay = 1;
        int firstDayInMounth = 1;
        string firstDay = new DateTime(year, month, 1).DayOfWeek.ToString();
        string[] daysOfWeekNames = culture.DateTimeFormat.DayNames;

        if (culture.DateTimeFormat.FirstDayOfWeek.ToString() == "Monday")
        {
            for (int i = 1; i < daysOfWeekNames.Length; i++)
            {
                Console.Write("{0,10} ", daysOfWeekNames[i]);
            }
            Console.WriteLine("{0,10} ", daysOfWeekNames[0]);

            switch (firstDay)
            {
                case "Monday": firstDayInMounth = 1; break;
                case "Tuesday": firstDayInMounth = 2; break;
                case "Wednesday": firstDayInMounth = 3; break;
                case "Thursday": firstDayInMounth = 4; break;
                case "Friday": firstDayInMounth = 5; break;
                case "Saturday": firstDayInMounth = 6; break;
                case "Sunday": firstDayInMounth = 7; break;
            }
        }
        else 
        {
            for (int i = 0; i < daysOfWeekNames.Length; i++)
            {
                Console.Write("{0,10} ", daysOfWeekNames[i]);
            }
            Console.WriteLine();

            switch (firstDay)
            {
                case "Monday": firstDayInMounth = 2; break;
                case "Tuesday": firstDayInMounth = 3; break;
                case "Wednesday": firstDayInMounth = 4; break;
                case "Thursday": firstDayInMounth = 5; break;
                case "Friday": firstDayInMounth = 6; break;
                case "Saturday": firstDayInMounth = 7; break;
                case "Sunday": firstDayInMounth = 1; break;
            }
        }

        for (int week = 0; week < calendarMatrix.GetLength(0); week++)
        {
            for (int day = 0; day < calendarMatrix.GetLength(1); day++, currentDay++)
            {
                if (currentDay > daysInMonth + nullDaysCount)
                {
                    break;
                }
                if (currentDay >= firstDayInMounth)
                {                   
                    calendarMatrix[week, day] = string.Format("{0,10} ", currentDay - nullDaysCount);
                }
                else
                {
                    calendarMatrix[week, day] = string.Format("{0,10} ", " ");
                    nullDaysCount++;
                }
            }
        }

        //print

        for (int week = 0; week < calendarMatrix.GetLength(0); week++)
        {
            for (int day = 0; day < calendarMatrix.GetLength(1); day++)
            {
                Console.Write(calendarMatrix[week, day]);
            }
            Console.WriteLine();
        }
    }
}
