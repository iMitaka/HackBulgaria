using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkReceiveBuffer
{
    public class MessageArgs : EventArgs
    {
        private string message;
        public MessageArgs(string message) 
        {
            this.message = message;
        }

        public string GetMessage 
        {
            get 
            {
                return this.message;
            }
        }
       
    }
}
