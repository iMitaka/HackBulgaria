using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATTAXCalculator
{
    public class NotSupportedCountryException : Exception
    {
        public NotSupportedCountryException()
        {
        }

        public NotSupportedCountryException(string message)
            : base(message)
        {
        }
    }
}
