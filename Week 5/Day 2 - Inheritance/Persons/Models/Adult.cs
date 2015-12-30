using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Models
{
    public class Adult : Person
    {
        private ICollection<Children> childrens;

        public Adult(string name,Gender gender) 
            : base(name,gender)
        {
            this.childrens = new HashSet<Children>();
        }

        public override string DailyStuff()
        {
            return "Go to work!";
        }

        public bool isBooring { get; set; }

        public ICollection<Children> Childrens 
        {
            get 
            {
                return this.childrens;
            }
            set 
            {
                this.childrens = value;
            }
        }

        public override string ToString()
        {
            int count = this.Childrens.Count;
            if (count == 1)
            {
                return string.Format("Hi I'm {3}! I {0} and I have {1} children. isBooring: {2}", this.DailyStuff(), count, this.isBooring, base.Name());
            }
            else if (count < 1)
            {
                return string.Format("Hi I'm {2}! I {0} and I dont have childrens. isBooring: {1}", this.DailyStuff(), this.isBooring, base.Name());
            }
            else 
            {
                return string.Format("Hi I'm {3}! I {0} and I have {1} childrens. isBooring: {2}", this.DailyStuff(), count, this.isBooring, base.Name());
            }          
        }
    }
}
