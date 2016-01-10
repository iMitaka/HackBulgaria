using System;

public class IncreasingAndDecreasingSequences
{
    public static void Main()
    {
        int[] sequence = { 1, 2, 3, 4, 5, 6 };

        //Results:

        Console.WriteLine(IsIncreasing(sequence));
        Console.WriteLine(IsDecreasing(sequence));
    }

    public static bool IsIncreasing(int[] sequence)
    {
        bool IsIncreasingSequence = true;
        for (int i = 0; i < sequence.Length; i += 2)
        {
            if (sequence[i] > sequence[i + 1])
            {
                IsIncreasingSequence = false;
                break;
            }
        }
        return IsIncreasingSequence;
    }

    public static bool IsDecreasing(int[] sequence)
    {
        bool IsDecreasingSequence = true;
        for (int i = 0; i < sequence.Length; i += 2)
        {
            if (sequence[i] < sequence[i + 1])
            {
                IsDecreasingSequence = false;
                break;
            }
        }
        return IsDecreasingSequence;
    }
}
