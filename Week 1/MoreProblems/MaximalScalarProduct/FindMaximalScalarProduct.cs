using System;
using System.Linq;
using System.Collections.Generic;

public class FindMaximalScalarProduct
{
    public static void Main()
    {
        List<int> v1 = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
        List<int> v2 = new List<int>() { 9, 8, 7, 6, 5, 4, 3 };

        MaxScalarProduct(v1, v2);
    }
    public static void MaxScalarProduct(List<int> v1, List<int> v2)
    {
        int scalarProduct = 0;
        for (int i = 0; i < v1.Count(); i++)
        {
            scalarProduct += (v1[i] * v2[i]);
        }

        int maxScalarProduct = scalarProduct;

        var permutationsV1 = GeneratePermutations(v1);
        var permutationsV2 = GeneratePermutations(v2);

        for (int i = 0; i < permutationsV1.Count(); i++)
        {
            int scalar = 0;
            for (int j = 0; j < v1.Count(); j++)
            {
                scalar += (permutationsV1[i][j] * v2[j]);
            }
            if (scalar > maxScalarProduct)
            {
                maxScalarProduct = scalar;
            }
        }
        for (int i = 0; i < permutationsV2.Count(); i++)
        {
            int scalar = 0;
            for (int j = 0; j < v2.Count(); j++)
            {
                scalar += (permutationsV2[i][j] * v1[j]);
            }
            if (scalar > maxScalarProduct)
            {
                maxScalarProduct = scalar;
            }
        }
        Console.WriteLine(maxScalarProduct);
    }

    public static List<List<T>> GeneratePermutations<T>(List<T> items)
    {
        // Make an array to hold the
        // permutation we are building.
        T[] current_permutation = new T[items.Count];

        // Make an array to tell whether
        // an item is in the current selection.
        bool[] in_selection = new bool[items.Count];

        // Make a result list.
        List<List<T>> results = new List<List<T>>();

        // Build the combinations recursively.
        PermuteItems<T>(items, in_selection,
            current_permutation, results, 0);

        // Return the results.
        return results;
    }
    public static void PermuteItems<T>(List<T> items, bool[] in_selection,T[] current_permutation, List<List<T>> results, int next_position)
    {
        // See if all of the positions are filled.
        if (next_position == items.Count)
        {
            // All of the positioned are filled.
            // Save this permutation.
            results.Add(current_permutation.ToList());
        }
        else
        {
            // Try options for the next position.
            for (int i = 0; i < items.Count; i++)
            {
                if (!in_selection[i])
                {
                    // Add this item to the current permutation.
                    in_selection[i] = true;
                    current_permutation[next_position] = items[i];

                    // Recursively fill the remaining positions.
                    PermuteItems<T>(items, in_selection,
                        current_permutation, results,
                        next_position + 1);

                    // Remove the item from the current permutation.
                    in_selection[i] = false;
                }
            }
        }
    }
}
