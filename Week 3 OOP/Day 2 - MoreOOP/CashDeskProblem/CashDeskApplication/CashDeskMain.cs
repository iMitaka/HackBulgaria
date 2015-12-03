using CashDesk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashDeskApplication
{
    public class CashDeskMain
    {
        public static void Main()
        {
            var cashDesk = new CashDesk.CashDesk();

            while (true)
            {
                string[] commandInput = Console.ReadLine().Split(' ');

                if (commandInput[0] == "takebill")
                {
                    var bill = new Bill(int.Parse(commandInput[1]));
                    cashDesk.TakeMoney(bill);
                }
                else if (commandInput[0] == "takebatch") 
                {
                    List<Bill> listOfBills = new List<Bill>();
                    for (int i = 1; i < commandInput.Length; i++)
                    {
                        listOfBills.Add(new Bill(int.Parse(commandInput[i])));
                    }
                    var newBatchBill = new BatchBill(listOfBills);
                    cashDesk.TakeMoney(newBatchBill);
                }
                else if (commandInput[0] == "total") 
                {
                    Console.WriteLine(cashDesk.Total());
                }
                else if (commandInput[0] == "inspect") 
                {
                    cashDesk.Inspect();
                }
                else if (commandInput[0] == "exit") 
                {
                    break;
                }
            }
        }
    }
}
