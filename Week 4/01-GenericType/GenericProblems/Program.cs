using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            Dequeue<string> some = new Dequeue<string>();
            some.AddToFront("aa");
            some.AddToFront("bb");
            some.AddToFront("cc");
            Console.WriteLine(some.PeekFromEnd());
            Console.WriteLine(some.PeekFromFront());
            
        }
    }
}
