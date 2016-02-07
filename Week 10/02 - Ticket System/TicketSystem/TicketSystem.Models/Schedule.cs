using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public virtual City StartingCity { get; set; }
        public virtual City EndCity { get; set; }
        public DateTime TimeOfTravel { get; set; }
        public virtual Train Train { get; set; }
        public decimal TicketPrice { get; set; }
    }
}
