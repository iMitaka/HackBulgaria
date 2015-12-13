using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATTAXCalculator
{
    public class VATTaxCalculator
    {   
        private List<CountryVatTax> countryVATTaxList;
        public VATTaxCalculator(List<CountryVatTax> countryVATTaxList)
        {
            this.countryVATTaxList = countryVATTaxList;
        }

        public decimal CalculateTax(decimal productPrice) 
        {
            var country = this.countryVATTaxList.Where(x => x.IsDefault == true).FirstOrDefault();
            if (country == null)
            {
                throw new NotSupportedCountryException("No default country found!");
            }
            var priceWithTax = productPrice * (decimal)country.VATTax;
            return priceWithTax;
        }
        public decimal CalculateTax(decimal productPrice, int countyId)
        {
            var country = this.countryVATTaxList.Where(x => x.CountryId == countyId).FirstOrDefault();
            if (country == null)
            {
                throw new NotSupportedCountryException(string.Format("No country found whith Id:{0}!", countyId));
            }
            var priceWithTax = productPrice * (decimal)country.VATTax;
            return priceWithTax;
        }
    }
}
