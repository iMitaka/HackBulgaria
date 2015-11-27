using System;
using System.Collections.Generic;

public class AppointmentsIntersection
{
    public static void Main()
    {
        DateTime[] startDates = 
            {
                new DateTime(2015,11,27,10,00,00),
                new DateTime(2015,11,27,11,00,00),
                new DateTime(2015,11,27,13,00,00)
            };

        TimeSpan[] durations = 
            {
                new TimeSpan(5,00,00),
                new TimeSpan(4,00,00),
                new TimeSpan(4,00,00)
            };

        FindIntersectingAppointments(startDates, durations);
    }

    public static void FindIntersectingAppointments(DateTime[] startDates, TimeSpan[] durations)
    {
        List<DateTime> endDates = new List<DateTime>();
        for (int i = 0; i < startDates.Length; i++)
        {
            endDates.Add(startDates[i] + durations[i]);
        }
        for (int i = 0; i < startDates.Length; i++)
        {
            var currentStartDate = startDates[i];
            var currentEndDate = endDates[i];

            for (int j = 0; j < startDates.Length; j++)
            {
                if (j == i)
                {
                    continue;
                }
                if (startDates[i] >= startDates[j] && endDates[i] <= endDates[j])
                {
                    var minutes = endDates[i] - startDates[i];
                    Console.WriteLine("The appointment starting at {0:dd/mm/yyyy hh:mm} intersects the appointment starting at {1:dd/mm/yyyy hh:mm} with exactly {2} minutes.", startDates[i], startDates[j], minutes.TotalMinutes);
                }
                else if (startDates[i] >= startDates[j] && endDates[i] > endDates[j])
                {
                    var minutes = endDates[j] - startDates[i];
                    Console.WriteLine("The appointment starting at {0:dd/mm/yyyy hh:mm} intersects the appointment starting at {1:dd/mm/yyyy hh:mm} with exactly {2} minutes.", startDates[i], startDates[j], minutes.TotalMinutes);
                }
                else if (startDates[i] < startDates[j] && endDates[i] <= endDates[j])
                {
                    var minutes = endDates[i] - startDates[j];
                    Console.WriteLine("The appointment starting at {0:dd/mm/yyyy hh:mm} intersects the appointment starting at {1:dd/mm/yyyy hh:mm} with exactly {2} minutes.", startDates[i], startDates[j], minutes.TotalMinutes);
                }
                else if (startDates[i] < startDates[j] && endDates[i] > endDates[j])
                {
                    var minutes = endDates[j] - startDates[j];
                    Console.WriteLine("The appointment starting at {0:dd/mm/yyyy hh:mm} intersects the appointment starting at {1:dd/mm/yyyy hh:mm} with exactly {2:mmmm} minutes.", startDates[i], startDates[j], minutes.Minutes);
                }
                Console.WriteLine();
            }
        }
    }
}
