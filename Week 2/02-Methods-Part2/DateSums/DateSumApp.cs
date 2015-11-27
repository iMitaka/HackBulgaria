using System;
using System.Collections.Generic;

public class DateSumApp
{
    public static void Main()
    {
        PrintDatesWithGivenSum(2015, 20);
    }

    public static void PrintDatesWithGivenSum(int year, int sum)
    {
        DateTime input = new DateTime(year, 1, 1);
        string yearToString = input.Year.ToString();
        int yearCalculation = 0;
        for (int i = 0; i < yearToString.Length; i++)
        {
            yearCalculation += int.Parse(yearToString[i].ToString());
        }
        List<string> datesResults = new List<string>();
        while (true)
        {          
            List<string> results = new List<string>();
            string dayToString = input.Day.ToString();
            int dayCalculation = 0;
            for (int i = 0; i < dayToString.Length; i++)
            {
                dayCalculation += int.Parse(dayToString[i].ToString());
                results.Add(string.Format("{0:D2}", int.Parse(dayToString[i].ToString())));
            }
            string monthToString = input.Month.ToString();
            int monthCalculation = 0;
            for (int i = 0; i < monthToString.Length; i++)
            {
                monthCalculation += int.Parse(monthToString[i].ToString());
                results.Add(string.Format("{0:D2}", int.Parse(monthToString[i].ToString())));
            }
            int result = yearCalculation + monthCalculation + dayCalculation;
            if (result == sum)
            {
                for (int i = 0; i < yearToString.Length; i++)
                {
                    results.Add(string.Format("{0:D2}", int.Parse(yearToString[i].ToString())));
                }
                string joinedString = string.Join("+", results);
                datesResults.Add(string.Format("{0:dd/MM/yyyy}: {1}={2}", input, joinedString, result));
            }
            input = input.AddDays(1);
            if (int.Parse(input.Year.ToString()) > year)
            {
                break;
            }
            results.Clear();
        }
        foreach (var date in datesResults)
        {
            Console.WriteLine(date);
        }
    }
}