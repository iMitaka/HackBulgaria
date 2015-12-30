using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious
{
    public abstract class Car
    {
        protected int mileage;
        public Car(int mileage) 
        {
            this.mileage = mileage;
        }
        public virtual bool IsEcoFriendly(bool testing) 
        {
            return true;
        }
    }
}
