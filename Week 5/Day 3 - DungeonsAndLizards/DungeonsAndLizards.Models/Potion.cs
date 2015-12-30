using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndLizards.Models
{
    public class Potion : ITreasure
    {
        private PotionType potionType;
        private int points;
        private string name;

        public Potion(PotionType potionType, string name, int points) 
        {
            this.potionType = potionType;
            this.points = points;
            this.name = name;
        }
        public string Name 
        {
            get 
            {
                return this.name;
            }
        }

        public PotionType PotionType 
        {
            get 
            {
                return this.potionType;
            }
        }

        public int Points 
        {
            get 
            {
                return this.points;
            }
        }
    }
}
