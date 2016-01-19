using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryCopy
{
    public class DirectoryCopyApp
    {
        public static void Main()
        {
            string directoryPath = @"../../AppTestDirectory";
            string newDirectoryPath = @"../../NewDirectory";

            //Now Create all of the directories:

            foreach (string dirPath in Directory.GetDirectories(directoryPath, "*", SearchOption.AllDirectories)) 
            {
                Directory.CreateDirectory(dirPath.Replace(directoryPath, newDirectoryPath));
            }

            //Copy all the files & Replaces any files with the same name:

            foreach (string newPath in Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories)) 
            {
                File.Copy(newPath, newPath.Replace(directoryPath, newDirectoryPath), true);
            }           
        }
    }
}
