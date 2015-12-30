using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Models
{
    public abstract class Bird : Animal
    {
        public virtual string MakeNest()
        {
            return null;
        }
    }
}
