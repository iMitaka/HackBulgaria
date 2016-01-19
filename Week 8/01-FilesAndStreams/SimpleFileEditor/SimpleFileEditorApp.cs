using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFileEditor
{
    public class SimpleFileEditorApp
    {
        [STAThread]
        public static void Main()
        {
            string filePath = string.Empty;
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Text Files|*.txt";
            if (f.ShowDialog() == DialogResult.OK)
            {               
                filePath = f.FileName;
                Console.WriteLine("File loaded: \"" + f.FileName + "\"");
                Console.WriteLine();
            }

            if (f.FileName == "")
            {
                Environment.Exit(-1);
            }

            string[] commands = { "exit", "list", "clear", "append", "appendline", "linecount" };

            while (true)
            {
                string[] command = Console.ReadLine().Split(' ');

                if (commands.Contains(command[0].ToLower()))
                {
                    if (command[0].ToLower() == "exit")
                    {
                        break;
                    }
                    else if (command[0].ToLower() == "list")
                    {
                        ListsTheContents(filePath);
                    }
                    else if (command[0].ToLower() == "clear")
                    {
                        Clear(filePath);
                    }
                    else if (command[0].ToLower() == "appendline")
                    {
                        AppendLine(filePath);
                    }
                    else if (command[0].ToLower() == "append")
                    {
                        if (command[1] == null)
                        {
                            Console.WriteLine("ERROR: You must tipe text to append!");
                            continue;
                        }
                        Append(filePath, command[1]);
                    }
                    else if (command[0].ToLower() == "linecount")
                    {
                        Linecount(filePath);
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: Command did not exist!");
                }
            }

        }

        public static void ListsTheContents(string path)
        {
            string[] text = File.ReadAllLines(path);
            foreach (var item in text)
            {
                Console.WriteLine(item);
            }
        }

        public static void Clear(string path)
        {
            File.WriteAllText(path, string.Empty);
        }

        public static void AppendLine(string path)
        {
            File.AppendAllText(path, Environment.NewLine);
        }

        public static void Append(string path, string text)
        {
            File.AppendAllText(path, text);
        }
        public static void Linecount(string path)
        {
            var lineCount = File.ReadLines(path).Count();
            Console.WriteLine(lineCount);
        }
    }
}
