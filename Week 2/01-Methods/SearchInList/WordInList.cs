using System;
using System.Linq;
using System.Collections.Generic;

public class WordInList
{
    public static void Main()
    {
        List<string> list = new List<string>() { "dog", "cat", "pandaria", "horse" };
        string searched = "panda";       

        //Result:
        int? foundIndex;
        bool isFound = TryFindSubstring(list, searched, out foundIndex);

        if (foundIndex != null)
        {
            Console.WriteLine("Word is Found: " + isFound + " At Index: " + foundIndex);
        }
        else
        {
            Console.WriteLine(isFound);
        }
    }

    public static bool TryFindSubstring(List<string> list, string searched, out int? foundIndex)
    {
        for (int i = 0; i < list.Count(); i++)
        {
            if (list[i].Contains(searched))
            {
                foundIndex = i;
                return true;
            }
        }

        foundIndex = null;
        return false;
    }
}
