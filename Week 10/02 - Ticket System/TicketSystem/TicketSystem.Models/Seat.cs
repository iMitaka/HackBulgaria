using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public SeatClasses Class { get; set; }
        public int Number { get; set; }
        public bool isToken { get; set; }
    }
}
