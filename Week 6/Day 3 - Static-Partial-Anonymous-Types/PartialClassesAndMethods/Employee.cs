using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialClassesAndMethods
{
    public partial class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; }
        public decimal Bonus { get; set; }
        partial void Print();
        public void PrintNames() 
        {
            this.Print();
        }
    }
}
