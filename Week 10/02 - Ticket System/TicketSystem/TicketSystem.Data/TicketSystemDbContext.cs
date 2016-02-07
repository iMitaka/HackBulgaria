using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Data.Migrations;
using TicketSystem.Models;

namespace TicketSystem.Data
{
    public class TicketSystemDbContext : DbContext
    {
        public TicketSystemDbContext()
            : base("TicketSystem")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TicketSystemDbContext, Configuration>());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Train> Trains { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<DiscountCard> DiscountCards { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
    }
}
