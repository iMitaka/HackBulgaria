using System;
using System.Collections.Generic;
public class Transversal
{
    public static void Main()
    {
        List<int> transversal = new List<int>() { 1, 2 };
        List<List<int>> family = new List<List<int>>();
        family.Add(new List<int> { 1, 5 });
        family.Add(new List<int> { 2, 3 });
        family.Add(new List<int> { 4, 7 });

        Console.WriteLine(IsTransversal(transversal, family));
    }

    public static bool IsTransversal(List<int> transversal, List<List<int>> family)
    {
        bool IsATransversal = true;

        foreach (var list in family)
        {
            foreach (var digit in transversal)
            {
                if (list.Contains(digit))
                {
                    IsATransversal = true;
                    break;
                }
                IsATransversal = false;
            }
        }

        return IsATransversal;
    }
}
