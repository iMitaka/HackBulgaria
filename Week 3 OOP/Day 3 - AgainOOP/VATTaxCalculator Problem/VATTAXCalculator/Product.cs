using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATTAXCalculator
{
    public class Product
    {
        public Product(int id, string name, decimal price, CountryVatTax country, int quantity) 
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.PriceAfterTax = (decimal)country.VATTax * price;
            this.Quantity = quantity;
        }

        public int Id { get; private set; }
        public decimal Price { get; private set; }
        public decimal PriceAfterTax { get; private set; }
        public string Name { get; private set; }
        public CountryVatTax Country { get; private set; }
        public int Quantity { get; private set; }

    }
}
