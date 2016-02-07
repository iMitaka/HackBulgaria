using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class User
    {
        private ICollection<Ticket> tickets;

        public User()
        {
            this.tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual DiscountCard DiscountCard { get; set; }
        public string CreditCardNumber { get; set; }
        public string Address { get; set; }
        public int ZIPCode {get;set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Ticket> Tickets 
        {
            get 
            {
                return this.tickets;
            }
            set 
            {
                this.tickets = value;
            }
        }
    }
}
