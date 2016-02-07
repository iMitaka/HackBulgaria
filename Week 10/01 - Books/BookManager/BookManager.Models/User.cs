using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Models
{
    public class User
    {
        private ICollection<Book> books;

        public User() 
        {
            this.books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pseudonim { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Book> Book 
        {
            get 
            {
                return this.books;
            }
            set 
            {
                this.books = value;
            }
        }
    }
}
