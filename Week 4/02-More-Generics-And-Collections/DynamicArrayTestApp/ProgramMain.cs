using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicArray;

namespace DynamicArrayTestApp
{
    public class ProgramMain
    {
        public static void Main()
        {
            DynamicArray<string> arrey = new DynamicArray<string>();
            arrey.Add("Pesho");
            arrey.Add("Gosho");
            Console.WriteLine(arrey.IndexOf("Pesho"));
            Console.WriteLine(arrey.Contains("Gosho"));
            Console.WriteLine(arrey.Contains("Ivan"));
            arrey.Remove("Pesho");
            arrey.InsertAt(1, "Pesho");
            arrey.Clear();
            Console.WriteLine(arrey.Capacity);
            Console.WriteLine(arrey.Count);
            arrey.Add("Ivo");
            arrey[0] = "Gosho";
            var newArrey = arrey.ToArray();
            Console.WriteLine();
            foreach (var item in arrey)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in newArrey)
            {
                Console.WriteLine(item);
            }
        }
    }
}
