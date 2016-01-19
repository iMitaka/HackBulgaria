using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BooksAndAuthors
{
    public class SerializerTestApp
    {
        public static void Main()
        {
            // IAuthorSerializer mySerializer = new AuthorSerializer();

            IAuthorSerializer mySerializer = new CustomTextSerializer();

            List<Book> books = new List<Book>();
            books.Add(new Book() { Title = "Harry Potter", PublishDate = DateTime.Now });
            books.Add(new Book() { Title = "Intro to programming", PublishDate = DateTime.Now });
            books.Add(new Book() { Title = "Lineage", PublishDate = DateTime.Now });

            Author author = new Author() { Name = "Pesho", Books = books, Email = "pesho_avtora@gmail.com" };

            mySerializer.Serializing(author, "pesho.txt");
            Author pesho = mySerializer.Deserializing("pesho.txt");

            Console.WriteLine(pesho.Name);
            Console.WriteLine(pesho.Email);
            Console.WriteLine("Books Count: " + pesho.Books.Count);
            foreach (var book in pesho.Books)
            {
                Console.WriteLine("- {0} : {1}", book.Title, book.PublishDate.ToShortDateString());
            }
        }
    }
}
