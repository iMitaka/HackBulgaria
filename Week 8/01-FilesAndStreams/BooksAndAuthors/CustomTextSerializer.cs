using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndAuthors
{
    public class CustomTextSerializer : IAuthorSerializer
    {
        public void Serializing(Author author, string fileName)
        {
            List<string> authorInfo = new List<string>();
            authorInfo.Add(author.Name);
            authorInfo.Add(author.Email);
            foreach (var book in author.Books)
            {
                authorInfo.Add(string.Format("{0}${1}", book.Title, book.PublishDate.ToShortDateString()));
            }

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (var line in authorInfo)
                {
                    sw.WriteLine(line);
                }
            }
        }

        public Author Deserializing(string filePath)
        {
            string line = string.Empty;
            List<string> authorInfo = new List<string>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    authorInfo.Add(line);
                }
            }
            Author author = new Author();
            author.Name = authorInfo[0];
            author.Email = authorInfo[1];
            for (int i = 2; i < authorInfo.Count; i++)
            {
                string[] bookInfo = authorInfo[i].Split('$');
                var book = new Book();
                book.Title = bookInfo[0];
                book.PublishDate = DateTime.Parse(bookInfo[1]);
                author.Books.Add(book);
            }

            return author;
        }
    }
}
