using BookManager.Data;
using BookManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.ConsoleApp
{
    public class BookManager
    {
        private static BookManagerDbContext data = new BookManagerDbContext();

        static void Main()
        {
            Console.Clear();
            Console.WriteLine("1.Insert a new book.");
            Console.WriteLine("2.Insert a new author.");
            Console.WriteLine("3.Get all books contained in the library - sorted in alphabetical order by title.");
            Console.WriteLine("4.Get all books contained in the library sorted by author.");
            Console.WriteLine("5.Get all books sorted by gendre.");
            Console.WriteLine("6.Get all types of genders a given author has written.");
            Console.WriteLine("7.Get all books written by a given author.");
            Console.WriteLine("8.Get the complete information(everything about the book and its authors) of a book by its ISBN");
            Console.WriteLine("9.Get the complete information by Title");
            Console.WriteLine("0.Loan a book to a user.");

            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)
            {
                Console.Clear();

                CreateNewBook(data);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Main();
            }
            else if (key.Key == ConsoleKey.D2)
            {
                Console.Clear();

                CreateNewAuthor(data);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Main();
            }
            else if (key.Key == ConsoleKey.D3)
            {
                Console.Clear();

                var books = data.Books.OrderBy(b => b.Title);
                int count = 1;
                foreach (var book in books)
                {
                    Console.WriteLine("{0}. {1}", count, book.Title);
                    count++;
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Main();
            }
            else if (key.Key == ConsoleKey.D4)
            {
                Console.Clear();

                var books = data.Books.OrderBy(b => b.Author.Id);
                int count = 1;
                foreach (var book in books)
                {
                    Console.WriteLine("{0}. {1} - {2}", count, book.Title, book.Author.FirstName + " " + book.Author.LastName);
                    count++;
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Main();
            }
            else if (key.Key == ConsoleKey.D5)
            {
                Console.Clear();

                var books = data.Books;
                int count = 1;
                foreach (var book in books)
                {
                    Console.Write("{0}. {1} - ", count, book.Title);
                    foreach (var genre in book.Genres)
                    {
                        Console.Write(genre.Name + ", ");
                    }
                    Console.WriteLine();
                    count++;
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Main();
            }
            else if (key.Key == ConsoleKey.D6)
            {
                Console.Clear();

                Console.Write("First Name: ");
                string firstName = Console.ReadLine();
                Console.Write("Last Name: ");
                string lastName = Console.ReadLine();

                var genreList = new List<Genre>();

                var author = data.Authors.Where(a => a.FirstName == firstName && a.LastName == lastName).FirstOrDefault();
                foreach (var book in author.Books)
                {
                    foreach (var genre in book.Genres)
                    {
                        if (!genreList.Contains(genre))
                        {
                            genreList.Add(genre);
                            Console.WriteLine(genre.Name);
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Main();
            }
            else if (key.Key == ConsoleKey.D7)
            {
                Console.Clear();

                Console.Write("First Name: ");
                string firstName = Console.ReadLine();
                Console.Write("Last Name: ");
                string lastName = Console.ReadLine();

                var author = data.Authors.Where(a => a.FirstName.ToLower() == firstName.ToLower() && a.LastName.ToLower() == lastName.ToLower()).FirstOrDefault();
                if (author != null)
                {
                    int count = 1;
                    foreach (var book in author.Books)
                    {
                        Console.WriteLine("{0}) {1}", count, book.Title);
                        count++;
                    }
                }
                else
                {
                    Console.WriteLine("Author not exist!");
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Main();
            }
            else if (key.Key == ConsoleKey.D8)
            {
                Console.Clear();

                Console.Write("ISBN: ");
                string isbn = Console.ReadLine();

                var book = data.Books.Where(b => b.ISBN == isbn).FirstOrDefault();
                Console.WriteLine("Book Title: {0}", book.Title);
                Console.WriteLine("Author: {0}", book.Author.FirstName + " " + book.Author.LastName);
                Console.WriteLine("Book Publisher: {0}", book.Publisher);
                Console.WriteLine("Publish Date: {0}", book.DatePublished.ToShortDateString());
                Console.WriteLine("Description: {0}", book.Description);

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Main();
            }
            else if (key.Key == ConsoleKey.D9)
            {
                Console.Clear();

                Console.Write("Title: ");
                string title = Console.ReadLine();

                var book = data.Books.Where(b => b.Title.Contains(title)).FirstOrDefault();

                Console.WriteLine("Book Title: {0}", book.Title);
                Console.WriteLine("Author: {0}", book.Author.FirstName + " " + book.Author.LastName);
                Console.WriteLine("Book Publisher: {0}", book.Publisher);
                Console.WriteLine("Publish Date: {0}", book.DatePublished.ToShortDateString());
                Console.WriteLine("Description: {0}", book.Description);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Main();
            }
            else if (key.Key == ConsoleKey.D0)
            {
                Console.Clear();

                int MAX_BOOK_LOAN = 5;

                var user = data.Users.FirstOrDefault();

                Console.WriteLine("Search for Book:");
                Console.WriteLine("1.By Title");
                Console.WriteLine("2.By ISBN");
                Book book = data.Books.FirstOrDefault();
                var chooseKey = Console.ReadKey();
                if (chooseKey.Key == ConsoleKey.D1)
                {
                    Console.WriteLine("-Title: ");
                    string title = Console.ReadLine();
                    book = data.Books.Where(b => b.Title.Contains(title)).FirstOrDefault();
                }
                else if (chooseKey.Key == ConsoleKey.D2)
                {
                    Console.WriteLine("-ISBN: ");
                    string isbn = Console.ReadLine();
                    book = data.Books.Where(b => b.ISBN == isbn).FirstOrDefault();
                }

                if (user.Book.Count >= MAX_BOOK_LOAN)
                {
                    Console.WriteLine("User can't loan more books then {0}", MAX_BOOK_LOAN);
                }
                else if (book != null)
                {
                    if (book.loanTillDate < DateTime.Now)
                    {
                        book.isLoan = false;
                        data.SaveChanges();
                    }

                    Console.WriteLine("Book Title: {0}", book.Title);
                    Console.WriteLine("Author: {0}", book.Author.FirstName + " " + book.Author.LastName);
                    Console.WriteLine("Book Publisher: {0}", book.Publisher);
                    Console.WriteLine("Publish Date: {0}", book.DatePublished.ToShortDateString());
                    Console.WriteLine("Description: {0}", book.Description);
                    Console.WriteLine();
                    if (book.isLoan == false)
                    {
                        Console.WriteLine("Are you want to loan this book? (y/n)");
                        string choice = Console.ReadLine();
                        if (choice.ToLower() == "y")
                        {
                            book.isLoan = true;
                            book.loanFromDate = DateTime.Now;
                            Console.Write("-Enter for how much days: ");
                            int days = int.Parse(Console.ReadLine());
                            book.loanTillDate = book.loanFromDate.AddDays(days);
                            book.LoanByUser = user;
                            user.Book.Add(book);

                            data.SaveChanges();
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("The book {0} is loan till {1}", book.Title, book.loanTillDate.ToShortDateString());
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("The Book not exist!");
                }
                Main();
            }

        }

        public static void CreateNewAuthor(BookManagerDbContext data)
        {
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Year Born: ");
            DateTime born = DateTime.Parse(Console.ReadLine());
            Console.Write("Year Died: ");
            DateTime died = died = DateTime.Parse(Console.ReadLine());

            var hasAuthor = data.Authors.Any(a => a.FirstName == firstName && a.LastName == lastName && a.YearBorn == born && a.YearDied == died);
            if (!hasAuthor)
            {
                var newAuthor = new Author() { FirstName = firstName, LastName = lastName, YearBorn = born, YearDied = died };
                data.Authors.Add(newAuthor);

                data.SaveChanges();
            }
            else
            {
                Console.WriteLine("Author already exist!");
            }
        }

        public static void CreateNewBook(BookManagerDbContext data)
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Author:");
            Console.Write("-First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("-Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("-Year Born: ");
            DateTime born = DateTime.Parse(Console.ReadLine());
            Console.Write("-Year Died: ");
            DateTime died = DateTime.Parse(Console.ReadLine());
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Console.Write("Date Published: ");
            DateTime published = DateTime.Parse(Console.ReadLine());
            Console.Write("Book Publisher: ");
            string publisher = Console.ReadLine();
            List<Genre> genres = new List<Genre>();
            Console.WriteLine("Select Book Genres:");
            Console.WriteLine("1. Comedy");
            Console.WriteLine("2. Action");
            Console.WriteLine("3. Fantasy");
            Console.Write("Enter your choises: ");
            string numbers = Console.ReadLine();
            string[] numbersSplited = numbers.Split(' ');
            foreach (var number in numbersSplited)
            {
                SelectGenres(genres, int.Parse(number), data);
            }
            Console.Write("Pages: ");
            int pages = int.Parse(Console.ReadLine());
            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();

            var hasAuthor = data.Authors.Any(a => a.FirstName == firstName && a.LastName == lastName && a.YearBorn == born && a.YearDied == died);
            if (!hasAuthor)
            {
                var newAuthor = new Author() { FirstName = firstName, LastName = lastName, YearBorn = born, YearDied = died };
                var book = new Book() { Author = newAuthor, DatePublished = published, Description = description, Genres = genres, ISBN = isbn, Pages = pages, Title = title, Publisher = publisher, isLoan = false };
                newAuthor.Books.Add(book);

                data.Authors.Add(newAuthor);

                data.SaveChanges();
            }
            else
            {
                var author = data.Authors.Where(a => a.FirstName == firstName && a.LastName == lastName && a.YearBorn == born && a.YearDied == died).FirstOrDefault();
                var book = new Book() { Author = author, DatePublished = published, Description = description, Genres = genres, ISBN = isbn, Pages = pages, Title = title, Publisher = publisher, isLoan = false };
                author.Books.Add(book);

                data.SaveChanges();
            }
        }

        public static void SelectGenres(List<Genre> genres, int number, BookManagerDbContext data)
        {
            switch (number)
            {
                case 1:
                    {
                        var genre = data.Genres.Where(g => g.Id == 1).FirstOrDefault();
                        genres.Add(genre);
                    }; break;
                case 2:
                    {
                        var genre = data.Genres.Where(g => g.Id == 2).FirstOrDefault();
                        genres.Add(genre);
                    }; break;
                case 3:
                    {
                        var genre = data.Genres.Where(g => g.Id == 3).FirstOrDefault();
                        genres.Add(genre);
                    }; break;
            }
        }
    }
}
