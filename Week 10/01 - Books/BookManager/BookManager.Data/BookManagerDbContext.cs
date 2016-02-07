using BookManager.Data.Migrations;
using BookManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Data
{
    public class BookManagerDbContext : DbContext
    {
        public BookManagerDbContext()
            : base("BookManager")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookManagerDbContext, Configuration>());
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
    }
}
