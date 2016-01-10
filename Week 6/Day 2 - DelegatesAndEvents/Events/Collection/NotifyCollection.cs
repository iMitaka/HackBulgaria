using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    public delegate void ChangedEventHandler(object sender, NotifyArgs e);

    public class NotifyCollection : ArrayList
    {
        public event ChangedEventHandler CollectionChanged; // EventHandler

        // Override some of the methods that can change the list;
        // invoke event after each
        public override int Add(object value)
        {
            int i = base.Add(value);
            string message = string.Format("Added new item with value={0} in collection!",value);
            NotifyArgs messageNotify = new NotifyArgs(message);
            this.OnChanged(messageNotify);
            return i;
        }

        public override void Clear()
        {
            base.Clear();
            string message = string.Format("Collection has cleared!");
            NotifyArgs messageNotify = new NotifyArgs(message);
            this.OnChanged(messageNotify);
        }

        public override object this[int index]
        {
            set
            {
                string message = string.Format("The value of index {0}=({1}) has change to: {2}", index, this[index], value);
                NotifyArgs messageNotify = new NotifyArgs(message);
                base[index] = value;
                this.OnChanged(messageNotify);
            }
        }

        // Invoke the Changed event; called whenever list changes
        private void OnChanged(NotifyArgs message)
        {
            if (this.CollectionChanged != null)
            {
                this.CollectionChanged(this, message);
            }
        }
    }
}
