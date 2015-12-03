using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashDesk
{
    public class CashDesk
    {
        private int money;
        private Dictionary<int, int> billsCollectin;

        public CashDesk() 
        {
            this.billsCollectin = new Dictionary<int, int>();
        }

        public void TakeMoney(object money) 
        {
            if (money is BatchBill)
            {
               var batchBill = money as BatchBill;
               
               foreach (Bill bill in batchBill)
               {
                   if (billsCollectin.ContainsKey((int)bill))
                   {
                       this.billsCollectin[(int)bill] += 1;
                   }
                   else 
                   {
                       billsCollectin.Add((int)bill, 1);
                   }
               }
               this.money += batchBill.Total;
            }
            else if (money is Bill) 
            {
                var someBill = money as Bill;
                if (billsCollectin.ContainsKey((int)someBill))
                {
                    this.billsCollectin[(int)someBill] += 1;
                }
                else
                {
                    billsCollectin.Add((int)someBill, 1);
                }
                this.money += someBill.Value;
            }
        }

        public int Total()
        {
            return this.money;
        }

        public void Inspect() 
        {
            Console.WriteLine("We have a total of {0}$ in the desk",this.Total());
            Console.WriteLine("We have the following count of bills, sorted in ascending order:");
            var collection = this.billsCollectin.OrderBy(x => x.Key);

            foreach (var bill in collection)
            {
                Console.WriteLine(bill.Value + " - " + bill.Key);
            }
        }
    }
}
