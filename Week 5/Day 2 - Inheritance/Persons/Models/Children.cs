using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Models
{
    public class Children : Person
    {
        private ICollection<Toy> toys;

        public Children(string name,Gender gender) 
            : base(name,gender) 
        {
            this.toys = new HashSet<Toy>();
        }

        public override string DailyStuff()
        {
            return "Play Games!";
        }

        public ICollection<Toy> Toys 
        {
            get 
            {
                return this.toys;
            }
            set 
            {
                this.toys = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Hello I'm {2}! I {0} I have {1} toys!", this.DailyStuff(), this.Toys.Count, base.Name());
        }
    }
}
