using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoGame
{
    public class LottoGame<T,U>
    {
        private List<Combination<T,U>> combinations;
        private Combination<T, U> winingCombination;
        public LottoGame(Combination<T,U> winingCombination)
        {
            this.combinations = new List<Combination<T,U>>();
            this.winingCombination = winingCombination;
        }

        public void Add(Combination<T,U> combination) 
        {
            foreach (var combin in this.combinations)
            {
                if (combin.Equals(combination))
                {
                    Console.WriteLine("This combination is already in game!");
                    return;
                }
            }
            combinations.Add(combination);
        }

        public LottoResult Validate() 
        {
            byte firstGropuMatchCount = 0;
            byte secondGroupMatchCount = 0;

            foreach (var combination in this.combinations)
            {
                foreach (var item in combination.FirstGroup)
                {
                    if (this.winingCombination.FirstGroup.Contains(item))
                    {
                        firstGropuMatchCount++;
                    }
                }

                foreach (var item in combination.SecondGropu)
                {
                    if (this.winingCombination.SecondGropu.Contains(item))
                    {
                        secondGroupMatchCount++;
                    }
                }
            }
            var result = new LottoResult();

            if (firstGropuMatchCount > 1 && secondGroupMatchCount > 1)
            {
                result.MatchedNumbersCount = (byte)(secondGroupMatchCount + firstGropuMatchCount);
                result.isWinning = true;
            }
            else 
            {
                result.MatchedNumbersCount = (byte)(secondGroupMatchCount + firstGropuMatchCount);
                result.isWinning = false;
            }

            return result;
        }

        private Combination<T,U> GetWinning() 
        {
            return this.winingCombination;
        }
    }
}
