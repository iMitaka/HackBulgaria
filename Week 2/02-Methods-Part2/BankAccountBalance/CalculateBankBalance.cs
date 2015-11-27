using System;
using System.Linq;
using System.Globalization;
using System.IO;
using System.Text;

public class CalculateBankBalance
{
    public static void Main()
    {
        System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
        customCulture.NumberFormat.NumberDecimalSeparator = ".";

        System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

        CultureInfo bgCulture = new CultureInfo("bg-BG");
        string[] input = File.ReadAllText(@"..\..\PeshoFile.txt", Encoding.Default).Split(new char[] { ';', ' ' });

        var fromDate = new DateTime(2015, 3, 28);
        var toDate = new DateTime(2015, 3, 31);

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
        Console.WriteLine("{0:C2}",balance);
    }
}
