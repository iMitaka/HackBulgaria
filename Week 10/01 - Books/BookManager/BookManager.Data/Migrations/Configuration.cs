namespace BookManager.Data.Migrations
{
    using BookManager.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookManager.Data.BookManagerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BookManager.Data.BookManagerDbContext context)
        {
            var data = new BookManagerDbContext();

            if (data.Genres.ToList().Count < 1)
            {
                var comedy = new Genre() { Name = "Comedy" };
                var action = new Genre() { Name = "Action" };
                var fantasy = new Genre() { Name = "Fantasy" };
                data.Genres.Add(comedy);
                data.Genres.Add(action);
                data.Genres.Add(fantasy);

                data.SaveChanges();
            }

            if (data.Users.ToList().Count < 1)
            {
                var user = new User(){ Email = "user@gmail.com", FirstName="Pesho", LastName="Peshev", Phone="0889999999", Pseudonim="Peshkata"};
                data.Users.Add(user);
                data.SaveChanges();
            }
        }
    }
}
