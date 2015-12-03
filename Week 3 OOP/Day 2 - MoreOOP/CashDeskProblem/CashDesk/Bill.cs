using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashDesk
{
    public class Bill 
    {
        private int amount;

        public Bill(int amount)
        {
            this.amount = amount;
        }

        public override string ToString()
        {
            return string.Format("A {0}$ Bill", this.amount);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Bill))
            {
                throw new FormatException("The object need to to Bill!");
            }
            var otherBill = obj as Bill;
            if (this.amount == otherBill.amount)
        	{
                return true;
        	}
            return false;
        }

        public static bool operator ==(Bill first, Bill second) 
        {
            return first.Equals(second);
        }

        public static bool operator !=(Bill first, Bill second) 
        {
            return !first.Equals(second);
        }

        public int Value 
        {
            get 
            {
                return this.amount;
            }
        }

        public static explicit operator int(Bill bill) 
        {
            return bill.amount;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + this.Value.GetHashCode();
                return hash;
            }
        }
    }
}
