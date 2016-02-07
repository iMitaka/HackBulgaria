namespace TicketSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TicketSystem.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TicketSystem.Data.TicketSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TicketSystem.Data.TicketSystemDbContext context)
        {
            if (context.Users.Count() < 1)
            {
                var user = new User()
           {
               Address = "Sofiq",
               FirstName = "Pesho",
               LastName = "Peshev",
               Email = "peshevski@gamil.com",
               Username = "PeshoNitroto",
               Password = Utility.DecodeText("peshopassword"),
               CreditCardNumber = Utility.DecodeText("010304052353"),
               ZIPCode = 1000,
           };
                context.Users.Add(user);
                context.SaveChanges();
            }
            
            if (context.DiscountCards.Count() < 1)
            {
                var card = new DiscountCard();
                card.CardType = DiscountCardType.Student;
                card.DiscountAmount = 50;
                card.isForFirstClass = true;
                context.DiscountCards.Add(card);

                var user = context.Users.FirstOrDefault();
                user.DiscountCard = card;

                context.SaveChanges();
            }
        }
    }
}
