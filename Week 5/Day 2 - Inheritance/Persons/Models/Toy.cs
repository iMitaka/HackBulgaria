using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Models
{
    public class Toy
    {
        public string Color { get; set; }
        public int Size { get; set; }

        public override string ToString()
        {
            return string.Format("I'm {1}sm {0} Toy!", this.Color, this.Size);
        }
    }
}
