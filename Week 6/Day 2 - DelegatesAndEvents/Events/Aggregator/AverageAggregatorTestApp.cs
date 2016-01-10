using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator
{
    public class AverageAggregatorTestApp
    {
        public static void Main()
        {
            AverageAggregator aggregator = new AverageAggregator();
            Console.WriteLine("----- Adding item 1");
            aggregator.AddNumber(5);
            Console.WriteLine("----- Adding item 2");
            aggregator.AddNumber(10);
            Console.WriteLine("----- Adding item 3");
            aggregator.AddNumber(20);
            Console.WriteLine("Avarage: " + aggregator.Avarage);
            aggregator.Changed += AvarageIsChanged;
            Console.WriteLine("----- Adding item 4");
            aggregator.AddNumber(50);
            Console.WriteLine("Avarage: " + aggregator.Avarage);
        }

        private static void AvarageIsChanged(object sender, EventArgs eventArgs) 
        {
            Console.WriteLine("The Avarage has changed!");
        }
    }
}
