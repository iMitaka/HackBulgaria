using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATTAXCalculator
{
    public class CountryVatTax
    {
        public CountryVatTax(int countryId, double VATTax, bool isDefault) 
        {
            this.CountryId = countryId;
            this.VATTax = VATTax;
            this.IsDefault = isDefault;
        }

        public int CountryId { get; private set; }
        public double VATTax { get; private set; }
        public bool IsDefault { get; private set; }
    }
}
