using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashDesk
{
    public class BatchBill : IEnumerable
    {
        private IEnumerable<Bill> bills;
        private int position;

        public BatchBill(IEnumerable<Bill> bills) 
        {
            this.bills = bills;
        }

        public int Count 
        {
            get 
            {
                return this.bills.Count();
            }
        }

        public int Total 
        {
            get 
            {
                int sum = 0;
                foreach (var bill in this.bills)
                {
                    sum += bill.Value;
                }
                return sum;
            }
        }

        public override string ToString()
        {
            return string.Format("Number of Bills: {0}, Total Bills value: {1}", this.Count, this.Total);
        }

        public IEnumerator GetEnumerator()
        {
            return this.bills.GetEnumerator();
        }
    }
}
