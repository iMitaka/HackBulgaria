using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Models
{
    public class Crocodile : Reptile
    {
        public override string Temperature()
        {
            Random rnd = new Random();
            int temperature = rnd.Next(10, 29);
            return string.Format("Temperature: {0}", temperature);
        }

        public override string Move()
        {
            return "I'm Crocodile, and i can move by swiming and to move on land too! My Temperature is: " + this.Temperature();
        }
    }
}
