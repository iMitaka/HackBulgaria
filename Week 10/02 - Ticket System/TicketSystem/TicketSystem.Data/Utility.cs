using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Data
{
    public static class Utility
    {
        public static string DecodeText(string text)
        {
            SHA1 sha1Algorithm = SHA1.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            byte[] sha1Bytes = sha1Algorithm.ComputeHash(bytes);
            string sha1Hash = Convert.ToBase64String(sha1Bytes);
            return sha1Hash;
        }
    }
}
