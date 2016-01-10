using System;
using System.Collections.Generic;

public class MaxSpanInList
{
    public static void Main()
    {
        List<int> spanNumbs = new List<int>() { 1, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 4, 3 };
        Console.WriteLine(MaxSpan(spanNumbs));
    }

    public static int MaxSpan(List<int> numbers)
    {
        List<Values> values = new List<Values>();
        numbers.ForEach(numb => values.Add(new Values(numb, false)));
        int maxSpan = 0;
        int currSpan = 1;

        for (int i = 0; i < values.Count; i++)
        {
            if (!values[i].Checked)
            {
                for (int b = i; b < values.Count; b++)
                {
                    if (values[i].Value == values[b].Value)
                    {
                        values[b].SetChecked();
                        currSpan = (b - i) + 1;
                    }
                }

                if (currSpan > maxSpan)
                {
                    maxSpan = currSpan;
                }
                currSpan = 1;
            }
        }

        return maxSpan;
    }

    public struct Values
    {
        public int Value;
        public bool Checked;
        public Values(int value, bool check)
        {
            Value = value;
            Checked = check;
        }
        public void SetChecked()
        {
            Checked = true;
        }
    }
}
