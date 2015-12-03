using System;
using System.Linq;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

public class CalculateBankBalance
{
    public static void Main()
    {
        CultureInfo customCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
        customCulture.NumberFormat.NumberDecimalSeparator = ".";

        Thread.CurrentThread.CurrentCulture = customCulture;

        string[] input = File.ReadAllText(@"..\..\PeshoFile.txt", Encoding.Default).Split(new char[] { ';', ' ' });

        var fromDate = new DateTime(2015, 3, 28);
        var toDate = new DateTime(2015, 3, 31);
        
        CultureInfo bgCulture = new CultureInfo("bg-BG");

        double recived = 0;
        double spended = 0;
        for (int i = 0; i < input.Count(); i += 3)
        {
            var currentDate = DateTime.Parse(input[i], bgCulture);
            if (currentDate >= fromDate && currentDate <= toDate)
            {
                if (input[i + 1] == "теглене")
                {
                    spended += double.Parse(input[i + 2].Replace("лв", ""));
                }
                else
                {
                    recived += double.Parse(input[i + 2].Replace("лв", ""));
                }
            }
        }

        double balance = recived - spended;
        Console.WriteLine("Balance for period {0} - {1}: {2:C2}", fromDate.ToShortDateString(), toDate.ToShortDateString(), balance);
    }
}
