using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionsSolution
{
    public class OddEvenComparer : IComparer<int?>
    {
        public int Compare(int? x, int? y)
        {
            if (x == null)
            {
                return -1;
            }
            else if (y == null) 
            {
                return 1;
            }
            else if ((x % 2 != 0) && (y % 2 == 0)) 
            {
                return 1;
            }
            else if ((x % 2 == 0) && (y % 2 != 0))
            {
                return -1;
            }
            else if ((x % 2 != 0) && (y % 2 != 0))
            {
                if (x > y)
                {
                    return 1;
                }
                else if (x < y)
                {
                    return -1;
                }
                else 
                {
                    return 0;
                }
            }
            else if ((x % 2 == 0) && (y % 2 == 0))
            {
                if (x < y)
                {
                    return 1;
                }
                else if (x > y)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else 
            {
                return 0;
            }
        }
    }
}
