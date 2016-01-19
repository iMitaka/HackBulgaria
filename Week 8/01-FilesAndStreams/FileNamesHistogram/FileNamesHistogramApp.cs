using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileNamesHistogram
{
    public class FileNamesHistogramApp
    {
        public static void Main()
        {
            string path = @"../../AppTestDirectory";

            Dictionary<string, int> myDict = new Dictionary<string, int>();

            GetFiles(path, myDict);

            foreach (var item in myDict)
            {
                Console.WriteLine(item.Key + " " + "[" + item.Value + "]");
            }
        }

        private static void GetFiles(string path, Dictionary<string, int> myDict)
        {
            DirectoryInfo[] cDirs = new DirectoryInfo(path).GetDirectories();

            FileInfo[] directories = new DirectoryInfo(path).GetFiles();
            foreach (var file in directories)
            {
                if (myDict.ContainsKey(file.Name))
                {
                    myDict[file.Name] += 1;
                }
                else
                {
                    myDict.Add(file.Name, 1);
                }
            }

            if (cDirs.Length < 1)
            {
                return;
            }
            foreach (var dir in cDirs)
            {
                GetFiles(dir.FullName, myDict);
            }
        }
    }
}
