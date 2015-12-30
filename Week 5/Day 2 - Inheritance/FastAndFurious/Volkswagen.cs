using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious
{
    public class Volkswagen : Car, IGermanBrand
    {
        public Volkswagen(int mileage) : base(mileage)
        {
        }
        public override bool IsEcoFriendly(bool testing)
        {
            if (testing)
            {
                return true;
            }
            return false;
        }

        public int Mileage
        {
            get 
            {
                return base.mileage;
            }
        }
    }
}
