using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackCompany.ConsoleApp
{
    public class HackCompanyUtility
    {
        private EmployeeUtility eployeeUtiliti;
        private CategoryUtility categoryUtility;
        private CustomerUtility customerUtility;
        private ProductUtility productUtility;
        private OrderUtility orderUtility;

        public HackCompanyUtility()
        {
            this.eployeeUtiliti = new EmployeeUtility();
            this.categoryUtility = new CategoryUtility();
            this.customerUtility = new CustomerUtility();
            this.productUtility = new ProductUtility();
            this.orderUtility = new OrderUtility();
        }

        public EmployeeUtility Employees 
        {
            get 
            {
                return this.eployeeUtiliti;
            }
        }

        public CategoryUtility Categories
        {
            get 
            {
                return this.categoryUtility;
            }
        }

        public CustomerUtility Customers
        {
            get 
            {
                return this.customerUtility;
            }
        }

        public ProductUtility Products
        {
            get 
            {
                return this.productUtility;
            }
        }

        public OrderUtility Orders
        {
            get 
            {
                return this.orderUtility;
            }
        }
    }
}
