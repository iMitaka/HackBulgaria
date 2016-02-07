using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime TripDateAndTime { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal PriceSold { get; set; }
        public virtual User UserSoldTo { get; set; }
        public int SeatNumber { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}
