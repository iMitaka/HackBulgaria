using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class Train
    {
        private ICollection<Seat> seats;

        public Train() 
        {
            this.seats = new HashSet<Seat>();
        }
        public int Id { get; set; }
        public virtual ICollection<Seat> Seats 
        {
            get 
            {
                return this.seats;
            }
            set 
            {
                this.seats = value;
            }
        }
        public string BriefDescription { get; set; }
        
    }
}
