using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkReceiveBuffer
{
    public delegate void ReconstructedEventHandler(object sender, MessageArgs e);

    public class ReceiveBuffer
    {
        public event ReconstructedEventHandler MessageReceived;

        private string message;

        public void BytesReceived(byte[] data)
        {
            var message = this.message;
            this.message = Encoding.UTF8.GetString(data);
            if (message != this.message)
            {
                OnChanged(string.Format("[2 bytes: {0}][{0} bytes: {1}]", this.message.Length, this.message));
            }
        }

        private void OnChanged(string message)
        {
            if (this.MessageReceived != null)
            {
                this.MessageReceived(this, new MessageArgs(message));
            }
        }
    }
}
