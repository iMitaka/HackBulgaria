using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeProblem
{
    public class Time
    {
        private DateTime date;

        public Time(DateTime date) 
        {
            this.date = date;
        }

        public override string ToString()
        {
            return string.Format("{0:hh:mm:ss dd.MM.yy}", this.date);
        }

        public static Time Now()
        {
            return new Time(DateTime.Now);
        }
    }
}
