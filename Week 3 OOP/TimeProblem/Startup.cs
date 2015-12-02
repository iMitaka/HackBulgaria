using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeProblem
{
    class Startup
    {
        static void Main()
        {
            var date = new DateTime(2015, 12, 1, 20, 00, 00);
            var currentDateTime = new Time(date);

            //Result: Print Current Date and Time:
            Console.WriteLine(currentDateTime.ToString());

            Console.WriteLine();
            
            //Result: Print static method Now(), Time now:
            Console.WriteLine(Time.Now());
            
        }
    }
}
