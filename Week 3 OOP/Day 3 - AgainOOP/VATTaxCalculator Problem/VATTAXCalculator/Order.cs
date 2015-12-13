using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATTAXCalculator
{
    public class Order
    {
        private List<int> productIds = new List<int>();
        private List<int> productQuantities = new List<int>();

        public Order(Dictionary<int, int> order)
        {
            // Separates order to product ids and product quantities
            this.ProductIds = order.Keys.ToList();
            this.ProductQuantities = order.Values.ToList();
        }

        public List<int> ProductIds
        {
            get { return this.productIds; }
            set { this.productIds = value; }
        }

        public List<int> ProductQuantities
        {
            get { return this.productQuantities; }
            set { this.productQuantities = value; }
        }
    }
}
