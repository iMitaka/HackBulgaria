using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Models
{
    public class Book
    {
        private ICollection<Genre> genres;

        public Book() 
        {
            this.genres = new HashSet<Genre>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public string Description { get; set; }
        public DateTime DatePublished { get; set; }
        public string Publisher { get; set; }
        public virtual ICollection<Genre> Genres 
        {
            get 
            {
                return this.genres;
            }
            set 
            {
                this.genres = value;
            }
        }
        public int Pages { get; set; }
        public string ISBN { get; set; }
        public bool isLoan { get; set; }
        public DateTime loanFromDate { get; set; }
        public DateTime loanTillDate { get; set; }
        public User LoanByUser { get; set; }

    }
}
