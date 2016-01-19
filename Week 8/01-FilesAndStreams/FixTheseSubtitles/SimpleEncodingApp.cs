using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixTheseSubtitles
{
    public class SimpleEncodingApp
    {
        public static void Main()
        {
            // Convert Windows-1251 to UTF-8:

            List<Byte[]> byteArreys = new List<byte[]>();

            string line = string.Empty;
            using (StreamReader sr = new StreamReader(@"..\..\lost.s04e11.hdtv.xvid-2hd.srt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    byteArreys.Add(Encoding.GetEncoding("windows-1251").GetBytes(line));
                }
            }

            using (StreamWriter sw = new StreamWriter("lost.s04e11.hdtv.xvid-2hd-UTF8.srt"))
            {
                foreach (var byteData in byteArreys)
                {
                    sw.WriteLine(Encoding.UTF8.GetString(byteData));
                }
            }
        }
    }
}
