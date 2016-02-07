using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class DiscountCard
    {
        public int Id { get; set; }
        public DiscountCardType CardType { get; set; }
        public int DiscountAmount { get; set; }
        public bool isForFirstClass { get; set; }
    }
}
