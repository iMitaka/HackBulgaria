using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Models
{
    public class Cat : Mammal , ILandAnimal
    {
        public string Greet()
        {
            return "Meow!";
        }

        public override string Move()
        {
            return this.Greet() + " I'm Cat and move on land!";
        }
    }
}
