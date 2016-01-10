using System;

public class MatrixBombingGame
{
    public static void Main()
    {
        int[,] matrix = new int[3, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };
        Console.WriteLine(MatrixBombing(matrix));
    }

    public static int MatrixBombing(int[,] m)
    {
        int maxDamage = 0;
        int currDamage = 0;
        for (int i = 0; i < m.GetLength(0); i++)
        {
            for (int b = 0; b < m.GetLength(1); b++)
            {
                currDamage = CalculateDamage(i, b, m);
                if (currDamage > maxDamage)
                {
                    maxDamage = currDamage;
                }
            }
        }

        return maxDamage;
    }

    public static int CalculateDamage(int i, int b, int[,] m)
    {
        int damage = 0;

        for (int x = -1; x < 2; x++)
        {
            for (int y = -1; y < 2; y++)
            {
                if (!(y == 0 && x == y))
                {
                    if (IsInside(i + x, b + y, m))
                    {
                        if (m[i + x, b + y] > m[i, b])
                        {
                            damage += m[i, b];
                        }
                        else
                        {
                            damage += m[i + x, b + y];
                        }
                    }
                }
            }
        }

        return damage;
    }

    public static bool IsInside(int x, int y, int[,] array)
    {
        return x >= 0 && x < array.GetLength(0) && y >= 0 && y < array.GetLength(1);
    }
}

