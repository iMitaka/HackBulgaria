using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToUpper
{
    public class TextToUpperApp
    {
        public static void Main()
        {
            string line = string.Empty;
            List<string> text = new List<string>();

            using (StreamReader sr = new StreamReader(@"..\..\TextToTest.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    text.Add(line);
                }
            }

            using (StreamWriter sw = new StreamWriter(@"..\..\TextToTest - ToUpper.txt")) 
            {
                foreach (var newLine in text)
                {
                    sw.WriteLine(newLine.ToUpper());
                }
            }
        }
    }
}
