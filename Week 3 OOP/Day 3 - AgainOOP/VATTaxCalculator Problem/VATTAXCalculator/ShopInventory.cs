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
            double sum = 0;
            foreach (Product product in this.productsList.Keys)
            {
                sum += (double)product.PriceAfterTax * product.Quantity;
            }

            return sum;
        }

        public double RequestOrder(Order order)
        {
            double sum = 0;
            foreach (int id in order.ProductIds)
            {
                foreach (Product prod in this.productsList.Keys)
                {
                    if (prod.Id == id && order.ProductQuantities[order.ProductIds.IndexOf(id)] <= prod.Quantity)
                    {
                        sum += (double)prod.PriceAfterTax * order.ProductQuantities[order.ProductIds.IndexOf(id)];
                    }
                }
            }

            if (sum == 0)
            {
<<<<<<< HEAD
                Console.WriteLine("In inventory dosn't have the requested quantities for products!");
                return -1;
=======
                Console.WriteLine("In ShopInventory not have requested quantities !");
                return null;
>>>>>>> origin/master
            }

            return sum;
        }
    }
}
