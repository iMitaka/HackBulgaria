using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList;

namespace LinkedListTestApp
{
    public class StartApp
    {
        public static void Main()
        {
            LinkedList<string> list = new LinkedList<string>();
            list.Add("Ivan");
            list.Add("Pesho");
            list.InsertAfter("Ivan", "Gosho");
            list.InsertAfter("Pesho", "Stoi4o");
            list.InsertBefore("Stoi4o", "Koko");
            list.InsertBefore("Ivan", "Dido");
            list.Remove("Stoi4o");
            list.InsertAt(5, "Ivo");
            list.RemoveAt(5);
            //list.Clear();
            Console.WriteLine(list[1]);
            list[1] = "Smqna";
            Console.WriteLine(list[1]);
            Console.WriteLine(list.Count());
            //list.InsertBefore("aaa", "bbb"); - exception!

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
