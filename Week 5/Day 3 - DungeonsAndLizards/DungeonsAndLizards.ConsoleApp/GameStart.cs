using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsAndLizards.Models;

namespace DungeonsAndLizards.ConsoleApp
{
    public class GameStart
    {
        public static void Main()
       {
            var map = new Dungeon(@"D:\level1.txt");
            map.Treasures.Add(new Weapon("The Sword Of Heroes", 50));
            map.Treasures.Add(new Spell("Frost Ball", 60, 20, 2));
            for (int i = 0; i < 5; i++)
            {
                map.Treasures.Add(new Potion(PotionType.health, "Health Potion", 50));
                map.Treasures.Add(new Potion(PotionType.mana, "Mana Potion", 50));
            }
            map.PrintMap();
            var hero = new Hero("Bron", "Dragonslayer", 100, 100, 2);
            var w = new Weapon("The Axe of Destiny", 20);
            hero.Equip(w);
            var s = new Spell("Fireball", 30, 50, 2);
            hero.Learn(s);
            map.Spawn(hero);
            map.PrintMap();
            map.MoveHero(Direction.Right);
            map.MoveHero(Direction.Down);
            map.PrintMap();
            map.HeroAttack("spell");
            map.MoveHero(Direction.Down);
            map.MoveHero(Direction.Down);
            map.PrintMap();
            map.HeroAttack("spell");
            map.PrintMap();
        }
    }
}
