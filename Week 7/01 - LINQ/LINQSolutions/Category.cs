using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSolutions
{
    public class Category
    {
        private List<Product> products;

        public Category() 
        {
            this.products = new List<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<Product> Products 
        {
            get 
            {
                return this.products;
            }
            set 
            {
                this.products = value;
            }
        }
    }
}
