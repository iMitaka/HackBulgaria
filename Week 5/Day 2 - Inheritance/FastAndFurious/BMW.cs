using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious
{
    public class BMW : Car, IGermanBrand
    {
        public BMW(int mileage) 
            : base(mileage)
        {
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
