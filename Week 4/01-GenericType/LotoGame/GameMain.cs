using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoGame
{
    public class GameMain
    {
        public static void Main()
        {
            
            Combination<int, string> winning = new Combination<int, string>(1, 2, 3, "ivan", "pesho", "gosho");
            LottoGame<int,string> game = new LottoGame<int,string>(winning);

            while (true)
            {
                string[] input = Console.ReadLine().Split(' ');
                Combination<int, string> combination = new Combination<int, string>(int.Parse(input[0]),int.Parse(input[1]),int.Parse(input[2]),input[3],input[4],input[5]);
                game.Add(combination);
                var result = game.Validate();
                Console.WriteLine("isWinning: {0}, MatchValues: {1}", result.isWinning,result.MatchedNumbersCount);
                if (input[0] == "stop")
                {
                    break;
                }
            }
        }
    }
}
