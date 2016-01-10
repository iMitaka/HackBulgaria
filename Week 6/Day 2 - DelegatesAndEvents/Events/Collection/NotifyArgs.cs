using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    public class NotifyArgs : EventArgs
    {
        private string message;

        public NotifyArgs(string message) 
        {
            this.message = message;
        }

        public string Message 
        {
            get 
            {
                return this.message;
            }
        }
    }
}
