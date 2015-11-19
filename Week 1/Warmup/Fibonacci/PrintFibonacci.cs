using System;

public class PrintFibonacci
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        FibNumber(number);
    }
    public static void FibNumber(int number)
    {
        int firstNumber = 1;
        int secondNumber = 1;
        if (number == 1)
        {
            Console.WriteLine(firstNumber);
        }
        else
        {
            Console.Write(firstNumber);
            Console.Write(secondNumber);
            int nextNumber = 0;
            for (int i = 0; i < number - 2; i++)
            {
                nextNumber = firstNumber + secondNumber;
                Console.Write(nextNumber);
                firstNumber = secondNumber;
                secondNumber = nextNumber;
            }
            Console.WriteLine();
        }
    }
}

