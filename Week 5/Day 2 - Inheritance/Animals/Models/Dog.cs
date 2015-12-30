using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Models
{
    public class Dog : Mammal , ILandAnimal
    {
        public string Greet()
        {
            return "Baw!";
        }

        public override string Move()
        {
            return this.Greet() + " I'm Dog and move on land!";
        }
    }
}
