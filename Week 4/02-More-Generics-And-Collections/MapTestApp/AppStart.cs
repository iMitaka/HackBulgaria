using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map;

namespace MapTestApp
{
    public class AppStart
    {
        public static void Main()
        {
            Map<int, string> map = new Map<int, string>();
            map.Add(1, "Gosho");
            map.Add(2, "Pesho");
            map.Add(3, "Ivan");
            map.Add(4, "Tisho");
            Console.WriteLine(map[1]);
            Console.WriteLine(map[2]);
            Console.WriteLine(map[3]);
            Console.WriteLine(map[4]);
            map[7] = "Mitko";
            Console.WriteLine(map[7]);
            
            //map.Clear();
            //Console.WriteLine(map[1]);
            Console.WriteLine();

            map.Remove(1);
            // Console.WriteLine(map[1]); -> exception
            Console.WriteLine(map[2]);
            Console.WriteLine(map[3]);
            Console.WriteLine(map[4]);
            Console.WriteLine(map[7]);

            Console.WriteLine();
            Console.WriteLine(map.ContainsKey(2));
            Console.WriteLine(map.ContainsValue("Pesho"));
            Console.WriteLine(map.ContainsKey(5));
            Console.WriteLine(map.ContainsValue("Koko"));
        }
    }
}
