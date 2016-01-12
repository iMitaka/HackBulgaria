using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialClassesAndMethods
{
    public class ProblemsTestApp
    {
        public static void Main()
        {
            Employee emplyee = new Employee();
            emplyee.FirstName = "Pesho";
            emplyee.LastName = "Ivanov";
            emplyee.Salary = 3000;
            emplyee.Bonus = 2000;
            emplyee.Position = "Boss";

            emplyee.PrintNames();
            emplyee.CalculateAllIncome();
            emplyee.CalculateBalance();
        }
    }
}
