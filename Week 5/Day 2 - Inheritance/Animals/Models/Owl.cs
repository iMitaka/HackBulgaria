using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Models
{
    public class Owl : Bird
    {
        public override string MakeNest()
        {
            return "Create Owl Nests!";
        }

        public override string Move()
        {
            return "I'm Owl and move by flaying! and can " + this.MakeNest();
        }
    }
}
