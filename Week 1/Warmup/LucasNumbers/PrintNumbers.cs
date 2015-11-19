using System;

public class PrintNumbers
{
    public static void Main()
    {
        //NthLucas(1);
        FirstNLucas(5);
    }

    public static void NthLucas(int number)
    {
        int firstNumber = 2;
        int secondNumber = 1;
        if (number == 1)
        {
            Console.WriteLine(firstNumber);
        }
        else if (number == 2)
        {
            Console.WriteLine(secondNumber);
        }
        else
        {
            int nextNumber = 0;
            for (int i = 0; i < number - 2; i++)
            {
                nextNumber = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = nextNumber;
            }
            Console.WriteLine(nextNumber);
        }
    }

    public static void FirstNLucas(int number)
    {
        int firstNumber = 2;
        int secondNumber = 1;
        if (number == 1)
        {
            Console.WriteLine(firstNumber);
        }
        else
        {
            Console.WriteLine(firstNumber);
            Console.WriteLine(secondNumber);
            int nextNumber = 0;
            for (int i = 0; i < number - 2; i++)
            {
                nextNumber = firstNumber + secondNumber;
                Console.WriteLine(nextNumber);
                firstNumber = secondNumber;
                secondNumber = nextNumber;
            }
        }
    }
}
