using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    public class NotifyCollectionTestApp
    {
        public static void Main()
        {
            NotifyCollection collection = new NotifyCollection();
            collection.CollectionChanged += OnCollectionChange;
            collection.Add(56);
            collection.Add(44);
            collection.Clear();
            collection.Add(55);
            collection[0] = 100;
        }

        private static void OnCollectionChange(object sender, NotifyArgs e) 
        {
            Console.WriteLine(e.Message);
        }
    }
}
