using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Models
{
    public abstract class Animal
    {
        public virtual string Move()
        {
            return null;
        }
        public virtual string Eat()
        {
            return null;
        }
        public virtual string GiveBirth()
        {
            return null;
        }
    }
}
