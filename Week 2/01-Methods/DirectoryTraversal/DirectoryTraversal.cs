using System;
using System.Collections.Generic;
using System.IO;

public class DirectoryTraversal
{
    public static void Main()
    {
        //Use your own path.
        string path = @"D:\Install";

        DirectoryInfo dir = new DirectoryInfo(path);

        //Result:
        var result = IterateDirectory(dir);

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }

    public static IEnumerable<string> IterateDirectory(DirectoryInfo dir)
    {
        DirectoryInfo[] directories = dir.GetDirectories("*", SearchOption.TopDirectoryOnly);

        foreach (var directory in directories)
        {
            yield return string.Format("<DIR> {0}:", directory);

            foreach (var file in directory.GetFiles("*.*", SearchOption.AllDirectories))
            {
                yield return string.Format(" - {0}", file);
            }

            foreach (var subDirectory in directory.GetDirectories("*", SearchOption.TopDirectoryOnly))
            {
                yield return string.Format(" - <DIR> {0}:", subDirectory);

                foreach (var file in subDirectory.GetFiles("*.*", SearchOption.AllDirectories))
                {
                    yield return string.Format("    -- {0}", file);
                }
            }

            yield return " ";
        }
    }
}
