using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkReceiveBuffer
{
    public static class PacketGenerator
    {
        public static byte[] ConvertToByteArray(string message) 
        {
            return Encoding.UTF8.GetBytes(message);
        }
    }
}
