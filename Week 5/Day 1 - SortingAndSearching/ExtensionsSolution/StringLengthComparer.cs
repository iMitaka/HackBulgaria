using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionsSolution
{
    public class StringLengthComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            int firstStringLength = 0;
            int secondStringLength = 0;
            if (x == null && y != null)
            {
                firstStringLength = 0;
                secondStringLength = y.Length;
            }
            else if (y == null && x != null)
            {
                firstStringLength = x.Length;
                secondStringLength = 0;
            }
            else if (x == null && y == null)
            {
                firstStringLength = 0;
                secondStringLength = 0;
            }
            else 
            {
                firstStringLength = x.Length;
                secondStringLength = y.Length;
            }

            if (firstStringLength > secondStringLength)
            {
                return 1;
            }
            else if (firstStringLength < secondStringLength)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
