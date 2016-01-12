using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousTypesAndNestedClasses
{
    public class ProblemsTestApp
    {
        public static void Main()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book() { Id = 2, Name = "BB" });
            books.Add(new Book() { Id = 1, Name = "BB" });
            books.Add(new Book() { Id = 3, Name = "BB" });
            books.Add(new Book() { Id = 1, Name = "DD" });
            books.Add(new Book() { Id = 44, Name = "BB" });
            books.Add(new Book() { Id = 33, Name = "BB" });

            List<Magazine> magazines = new List<Magazine>();
            magazines.Add(new Magazine() { ISBN = 2, Title = "AAA" });
            magazines.Add(new Magazine() { ISBN = 5, Title = "AAA" });
            magazines.Add(new Magazine() { ISBN = 3, Title = "AAA" });
            magazines.Add(new Magazine() { ISBN = 1, Title = "CC" });
            magazines.Add(new Magazine() { ISBN = 7, Title = "CC" });
            magazines.Add(new Magazine() { ISBN = 10, Title = "CC" });
            magazines.Add(new Magazine() { ISBN = 10, Title = "AAA" });

            var list = MagazineAndBookSorter.Sort(books, magazines);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
