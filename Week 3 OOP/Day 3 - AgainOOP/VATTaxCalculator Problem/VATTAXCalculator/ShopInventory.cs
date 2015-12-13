using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATTAXCalculator
{
    public class ShopInventory
    {
        private Dictionary<Product, int> productsList = new Dictionary<Product, int>();

        public ShopInventory(Product productToAdd)
        {
            // Checks if product exists, if so, increments its quantity by 1, else adds as new item
            if (!this.productsList.Keys.Contains(productToAdd))
            {
                this.productsList.Add(productToAdd, 1);
            }
            else
            {
                this.productsList[productToAdd]++;
            }
        }

        public ShopInventory(List<Product> listOfProducts)
        {
            // Adds each product via the aforementioned logic
            foreach (Product prod in listOfProducts)
            {
                if (!this.productsList.Keys.Contains(prod))
                {
                    this.productsList.Add(prod, 1);
                }
                else
                {
                    this.productsList[prod]++;
                }
            }
        }

        public double Audit()
        {
            // Sums all the product values times their quantity
            double sum = 0;
            foreach (Product product in this.productsList.Keys)
            {
                sum += (double)product.PriceAfterTax * product.Quantity;
            }

            return sum;
        }

        public double RequestOrder(Order order)
        {
            // Takes an order and returns the order price
            double sum = 0;
            foreach (int id in order.ProductIds)
            {
                foreach (Product prod in this.productsList.Keys)
                {
                    // Finds the product via its ID and returns its price times the requested quantity
                    if (prod.Id == id && order.ProductQuantities[order.ProductIds.IndexOf(id)] <= prod.Quantity)
                    {
                        sum += (double)prod.PriceAfterTax * order.ProductQuantities[order.ProductIds.IndexOf(id)];
                    }
                }
            }

            if (sum == 0)
            {
                Console.WriteLine("ERROR: None of the items you ordered are available in the requested quantities !");
                return -1;
            }

            return sum;
        }
    }
}
