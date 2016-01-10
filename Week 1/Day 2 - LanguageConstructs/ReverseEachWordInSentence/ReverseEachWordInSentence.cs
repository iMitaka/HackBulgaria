using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ReverseEachWordInSentence
{
    public static void Main()
    {

        string inputString = Console.ReadLine();

        //Result:

        Console.WriteLine(ReverseEveryWord(inputString));

        //Example:

        //Hello C#!
        //olleH !#C
    }

    public static string ReverseEveryWord(string original)
    {
        string[] splitString = original.Split(' ');
        List<string> listOfReversedWords = new List<string>();
        StringBuilder sb = new StringBuilder();
        foreach (var word in splitString)
        {
            var reversed = word.ToList();
            reversed.Reverse();
            foreach (var item in reversed)
            {
                sb.Append(item);
            }
            listOfReversedWords.Add(sb.ToString());
            sb.Clear();
        }

        foreach (var word in listOfReversedWords)
        {
            sb.Append(word + " ");
        }

        return sb.ToString();
    }
}
