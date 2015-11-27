using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class RandomNumbers
{
    public static void Main()
    {
        GenerateRandomMatrix(3, 3, "Text.txt");
    }

    public static void GenerateRandomMatrix(int rows, int columns, string fileName)
    {
        List<string> results = new List<string>();
        Random rnd = new Random();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                sb.Append(string.Format("{0,3:F2} ", rnd.NextDouble() * 1000));
            }
            results.Add(sb.ToString());
            sb.Clear();
        }
        File.WriteAllLines(fileName, results);
    }
}
