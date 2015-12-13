using System;
using System.Collections.Generic;

namespace VATTAXCalculator
{
    public class CalculatorMain
    {
        public static void Main()
        {
            CountryVatTax Bulgaria = new CountryVatTax(1, 2.5, true);
            CountryVatTax Germany = new CountryVatTax(2, 3.5, true);
            CountryVatTax Russia = new CountryVatTax(3, 5.5, false);
            List<CountryVatTax> countryList = new List<CountryVatTax>();
            countryList.Add(Bulgaria);
            countryList.Add(Germany);
            countryList.Add(Russia);

            VATTaxCalculator calculator = new VATTaxCalculator(countryList);

            Console.WriteLine(calculator.CalculateTax(150));
            Console.WriteLine(calculator.CalculateTax(150, 3));

        }
    }
}
