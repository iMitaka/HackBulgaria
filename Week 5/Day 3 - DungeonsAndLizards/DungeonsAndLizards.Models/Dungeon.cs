using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndLizards.Models
{
    public class Dungeon
    {
        private char[,] map;
        private int currentRow;
        private int currentCol;
        private Hero hero;
        private List<ITreasure> dungenTreasures;

        public Dungeon(string mapFilePath)
        {
            string[] dungen = File.ReadAllText(mapFilePath).Split('\n');
            int width = dungen[0].Length - 1;
            int height = dungen.Length;
            this.map = new char[height, width];
            for (int i = 0; i < this.map.GetLength(0); i++)
            {
                var rowElemets = dungen[i];
                for (int j = 0; j < this.map.GetLength(1); j++)
                {
                    this.map[i, j] = rowElemets[j];
                }
            }
            this.dungenTreasures = new List<ITreasure>();
        }

        public List<ITreasure> Treasures 
        {
            get 
            {
                return this.dungenTreasures;
            }
            set 
            {
                this.dungenTreasures = value;
            }
        }

        public void PrintMap()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            for (int row = 0; row < this.map.GetLength(0); row++)
            {
                for (int col = 0; col < this.map.GetLength(1); col++)
                {
                    if (this.map[row, col] == 'H')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(this.map[row, col]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (this.map[row, col] == 'E')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(this.map[row, col]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (this.map[row, col] == 'T')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(this.map[row, col]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (this.map[row, col] == 'G')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(this.map[row, col]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (this.map[row, col] == 'S')
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(this.map[row, col]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (this.map[row, col] == '#')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(this.map[row, col]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(this.map[row, col]);
                    }

                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        public bool Spawn(Hero hero)
        {
            for (int row = 0; row < this.map.GetLength(0); row++)
            {
                for (int col = 0; col < this.map.GetLength(1); col++)
                {
                    if (this.map[row, col] == 'S')
                    {
                        this.currentRow = row;
                        this.currentCol = col;
                        this.map[row, col] = 'H';
                        this.hero = hero;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool MoveHero(Direction direction)
        {
            if (this.hero.IsAlive())
            {
                Enemy enemy = new Enemy(100, 100, 20);

                this.hero.TakeMana(this.hero.ManaRegen);
                switch (direction)
                {
                    case Direction.Up:
                        {
                            if (this.currentRow - 1 < 0 || this.map[this.currentRow - 1, this.currentCol] == '#' || this.map[this.currentRow - 1, this.currentCol] == 'S')
                            {
                                return false;
                            }
                            else if (this.map[this.currentRow - 1, this.currentCol] == 'T')
                            {
                                PickTreasure();
                            }
                            else if (this.map[this.currentRow - 1, this.currentCol] == 'E')
                            {
                                StartFight(enemy, this.currentRow - 1, this.currentCol);
                                return true;
                            }
                            else if (this.map[this.currentRow - 1, this.currentCol] == 'G')
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("You escaped from Dungen!");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                return true;
                            }

                            this.map[this.currentRow, this.currentCol] = '.';
                            this.map[this.currentRow - 1, this.currentCol] = 'H';
                            this.currentRow = this.currentRow - 1;
                            return true;

                        }
                    case Direction.Down:
                        {
                            if (this.currentRow + 1 >= this.map.GetLongLength(0) || this.map[this.currentRow + 1, this.currentCol] == '#' || this.map[this.currentRow + 1, this.currentCol] == 'S')
                            {
                                return false;
                            }
                            else if (this.map[this.currentRow + 1, this.currentCol] == 'T')
                            {
                                PickTreasure();
                            }
                            else if (this.map[this.currentRow + 1, this.currentCol] == 'E')
                            {
                                StartFight(enemy, this.currentRow + 1, this.currentCol);
                                return true;
                            }
                            else if (this.map[this.currentRow + 1, this.currentCol] == 'G')
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("You escaped from Dungen!");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                return true;
                            }

                            this.map[this.currentRow, this.currentCol] = '.';
                            this.map[this.currentRow + 1, this.currentCol] = 'H';
                            this.currentRow = currentRow + 1;
                            return true;

                        }
                    case Direction.Left:
                        {
                            if (this.currentCol - 1 > 0 || this.map[this.currentRow, this.currentCol - 1] == '#' || this.map[this.currentRow, this.currentCol - 1] == 'S')
                            {
                                return false;
                            }
                            else if (this.map[this.currentRow, this.currentCol - 1] == 'T')
                            {
                                PickTreasure();
                            }
                            else if (this.map[this.currentRow, this.currentCol - 1] == 'E')
                            {
                                StartFight(enemy, this.currentRow, this.currentCol - 1);
                                return true;
                            }
                            else if (this.map[this.currentRow, this.currentCol - 1] == 'G')
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("You escaped from Dungen!");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                return true;
                            }

                            this.map[this.currentRow, this.currentCol] = '.';
                            this.map[this.currentRow, this.currentCol - 1] = 'H';
                            this.currentCol = this.currentCol - 1;
                            return true;

                        }
                    case Direction.Right:
                        {
                            if (this.currentCol + 1 > this.map.GetLength(1) - 1 || this.map[this.currentRow, this.currentCol + 1] == '#' || this.map[this.currentRow, this.currentCol + 1] == 'S')
                            {
                                return false;
                            }
                            else if (this.map[this.currentRow, this.currentCol + 1] == 'T')
                            {
                                PickTreasure();
                            }
                            else if (this.map[this.currentRow, this.currentCol + 1] == 'E')
                            {
                                StartFight(enemy, this.currentRow, this.currentCol + 1);
                                return true;
                            }
                            else if (this.map[this.currentRow, this.currentCol + 1] == 'G')
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("You escaped from Dungen!");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                return true;
                            }

                            this.map[this.currentRow, this.currentCol] = '.';
                            this.map[this.currentRow, this.currentCol + 1] = 'H';
                            this.currentCol = this.currentCol + 1;
                            return true;
                        }
                    default: return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void PickTreasure()
        {
            if (this.dungenTreasures.Count < 1)
            {
                Console.WriteLine("No treasures found!");
                Console.WriteLine();
                return;
            }
            Random rnd = new Random();
            int number = rnd.Next(0, dungenTreasures.Count);
            var treasure = dungenTreasures[number];

            if (treasure is Potion)
            {
                var potion = treasure as Potion;
                if (potion.PotionType == PotionType.health)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (this.hero.TakeHealing(potion.Points))
                    {
                        Console.WriteLine("Found {0}. Hero health is {1}", potion.Name, this.hero.GetHealth());
                    }
                    else
                    {
                        Console.WriteLine("Found {0}. Hero health is max.", potion.Name);
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    if (this.hero.TakeMana(potion.Points))
                    {
                        Console.WriteLine("Found {0}. Hero mana is {1}", potion.Name, this.hero.GetMana());
                    }
                    else
                    {
                        Console.WriteLine("Found {0}. Hero mana is max.", potion.Name);
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            else if (treasure is Weapon)
            {
                var weapon = treasure as Weapon;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Found {0}. Damage:{1}", weapon.Name, weapon.Damage);
                Console.ForegroundColor = ConsoleColor.Gray;
            choseOption:
                Console.Write("Are you wont to equip it? (y/n): ");
                var option = Console.ReadLine();
                if (option.ToLower() == "y")
                {
                    this.hero.Equip(weapon);
                }
                else if (option.ToLower() == "n") { }
                else
                {
                    goto choseOption;
                }
                Console.WriteLine();
            }
            else if (treasure is Spell)
            {
                var spell = treasure as Spell;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Found {0}. Damage:{1}, Cast Range:{2}, Mana Cost:{3}", spell.Name, spell.Damage, spell.CastRange, spell.ManaCost);
                Console.ForegroundColor = ConsoleColor.Gray;
            choseOption:
                Console.Write("Are you wont to learn it? (y/n): ");
                var option = Console.ReadLine();
                if (option.ToLower() == "y")
                {
                    this.hero.Learn(spell);
                }
                else if (option.ToLower() == "n") { }
                else
                {
                    goto choseOption;
                }
            }
            Console.WriteLine();
        }

        public void HeroAttack(string by)
        {
            if (this.hero.IsAlive() == true)
            {
                if (by.ToLower() == "spell" && this.hero.CanCast() && this.hero.Spell != null)
                {
                    Enemy enemy = new Enemy(100, 100, 20);
                   // var enemySpell = new Spell("Fire Storm", 20, 30, 2);
                   // enemy.Spell = enemySpell;

                    for (int i = 1; i <= this.hero.Spell.CastRange; i++)
                    {
                        if ((this.currentRow - i == '#') || (this.currentRow - i < 0))
                        {
                            break;
                        }
                        else if (this.map[currentRow - i, currentCol] == 'E')
                        {
                            StartFight(enemy, this.currentRow - i, this.currentCol);
                            return;
                        }
                    }
                    for (int i = 1; i <= this.hero.Spell.CastRange; i++)
                    {
                        if ((this.currentRow + i == '#') || (this.currentRow + i > this.map.GetLength(0) - 1))
                        {
                            break;
                        }
                        else if (this.map[currentRow + i, currentCol] == 'E')
                        {
                            StartFight(enemy, this.currentRow + i, this.currentCol);
                            return;
                        }
                    }
                    for (int i = 1; i <= this.hero.Spell.CastRange; i++)
                    {
                        if ((this.currentCol - i == '#') || (this.currentCol - i < 0))
                        {
                            break;
                        }
                        else if (this.map[currentRow, currentCol - i] == 'E')
                        {
                            StartFight(enemy, this.currentRow, this.currentCol - i);
                            return;
                        }
                    }
                    for (int i = 1; i <= this.hero.Spell.CastRange; i++)
                    {
                        if ((this.currentCol + i == '#') || (this.currentCol + i > this.map.GetLength(1) - 1))
                        {
                            Console.WriteLine("Nothing in casting range {0}", this.hero.Spell.CastRange);
                            Console.WriteLine();
                            break;
                        }
                        else if (this.map[currentRow, currentCol + i] == 'E')
                        {
                            StartFight(enemy, this.currentRow, this.currentCol + i);
                            return;
                        }
                        else if (i == this.hero.Spell.CastRange)
                        {
                            Console.WriteLine("Nothing in casting range {0}", this.hero.Spell.CastRange);
                            Console.WriteLine();
                        }
                    }
                }
                else if (this.hero.Spell == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("No skill learned.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("No mana for skill.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                }
            }
        }

        private void StartFight(Enemy enemy, int enemyCurrentRow, int enemyCurrentCol)
        {
            var enemyDeffoultRow = enemyCurrentRow;
            var enemyDeffoultCol = enemyCurrentCol;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("A fight is started between our Hero(health={0}, mana={1}) and Enemey(health={2}, mana={3}, damage={4}):", this.hero.GetHealth(), this.hero.GetMana(), enemy.GetHealth(), enemy.GetMana(), enemy.Attack(enemy.Weapon));
            Console.WriteLine();
            bool isChecked = false;
            while (true)
            {
                if (!this.hero.CanCast() && !isChecked)
                {
                    isChecked = true;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Hero does not have mana for another {0}.", this.hero.Spell.Name);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                if ((this.hero.Spell.Damage >= this.hero.Weapon.Damage || (this.currentRow > enemyCurrentRow || this.currentRow < enemyCurrentRow || this.currentCol > enemyCurrentCol || this.currentCol < enemyCurrentCol)) && this.hero.CanCast())
                {
                    enemy.TakeDamage(hero.Attack(hero.Spell));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Hero casts a {0}, hits enemy for {1} dmg. Enemy health is {2}", this.hero.Spell.Name, this.hero.Spell.Damage, enemy.GetHealth());
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    if (enemyCurrentRow < this.currentRow)
                    {
                        this.map[currentRow, currentCol] = '.';
                        this.currentRow--;
                        this.map[currentRow, currentCol] = 'H';
                        Console.WriteLine("Hero moves one square to up in order to get to the enemy. This is hero move.");
                    }
                    else if (enemyCurrentRow > this.currentRow)
                    {
                        this.map[currentRow, currentCol] = '.';
                        this.currentRow++;
                        this.map[currentRow, currentCol] = 'H';
                        Console.WriteLine("Hero moves one square to down in order to get to the enemy. This is hero move.");
                    }
                    else if (enemyCurrentCol < this.currentCol)
                    {
                        this.map[currentRow, currentCol] = '.';
                        this.currentCol--;
                        this.map[currentRow, currentCol] = 'H';
                        Console.WriteLine("Hero moves one square to left in order to get to the enemy. This is hero move.");
                    }
                    else if (enemyCurrentCol > this.currentCol)
                    {
                        this.map[currentRow, currentCol] = '.';
                        this.currentCol++;
                        this.map[currentRow, currentCol] = 'H';
                        Console.WriteLine("Hero moves one square to right in order to get to the enemy. This is hero move.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        enemy.TakeDamage(hero.Attack(hero.Weapon));
                        Console.WriteLine("Hero hits with {0} for {1} dmg. Enemy health is {2}", this.hero.Weapon.Name, this.hero.Weapon.Damage, enemy.GetHealth());
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                if (!enemy.IsAlive())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Enemy is dead!");
                    if (this.map[enemyDeffoultRow, enemyDeffoultCol] != 'H')
                    {
                        this.map[enemyDeffoultRow, enemyDeffoultCol] = '.';
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (enemyCurrentRow < this.currentRow)
                {
                    if (enemy.Spell != null)
                    {
                        var distance = this.currentRow - enemyCurrentRow;
                        if (enemy.CanCast() && distance <= enemy.Spell.CastRange)
                        {
                            hero.TakeDamage(enemy.Attack(enemy.Spell));
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Enemy casts a {0}, hits hero for {1} dmg. Hero health is {2}", enemy.Spell.Name, enemy.Spell.Damage, this.hero.GetHealth());
                        }
                        else
                        {
                            enemyCurrentRow++;
                            Console.WriteLine("Enemy moves one square to down in order to get to the hero. This is his move.");
                        }
                    }
                    else
                    {
                        enemyCurrentRow++;
                        Console.WriteLine("Enemy moves one square to down in order to get to the hero. This is his move.");
                    }
                }
                else if (enemyCurrentRow > this.currentRow)
                {
                    if (enemy.Spell != null)
                    {
                        var distance = enemyCurrentRow - this.currentRow;
                        if (enemy.CanCast() && distance <= enemy.Spell.CastRange)
                        {
                            hero.TakeDamage(enemy.Attack(enemy.Spell));
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Enemy casts a {0}, hits hero for {1} dmg. Hero health is {2}", enemy.Spell.Name, enemy.Spell.Damage, this.hero.GetHealth());
                        }
                        else
                        {
                            enemyCurrentRow--;
                            Console.WriteLine("Enemy moves one square to up in order to get to the hero. This is his move.");
                        }
                    }
                    else
                    {
                        enemyCurrentRow--;
                        Console.WriteLine("Enemy moves one square to up in order to get to the hero. This is his move.");
                    }
                }
                else if (enemyCurrentCol < this.currentCol)
                {
                    if (enemy.Spell != null)
                    {
                        var distance = this.currentCol - enemyCurrentCol;
                        if (enemy.CanCast() && distance <= enemy.Spell.CastRange)
                        {
                            hero.TakeDamage(enemy.Attack(enemy.Spell));
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Enemy casts a {0}, hits hero for {1} dmg. Hero health is {2}", enemy.Spell.Name, enemy.Spell.Damage, this.hero.GetHealth());
                        }
                        else
                        {
                            enemyCurrentCol++;
                            Console.WriteLine("Enemy moves one square to the right in order to get to the hero. This is his move.");
                        }
                    }
                    else
                    {
                        enemyCurrentCol++;
                        Console.WriteLine("Enemy moves one square to the right in order to get to the hero. This is his move.");
                    }
                }
                else if (enemyCurrentCol > this.currentCol)
                {
                    if (enemy.Spell != null)
                    {
                        var distance = enemyCurrentCol - this.currentCol;
                        if (enemy.CanCast() && distance <= enemy.Spell.CastRange)
                        {
                            hero.TakeDamage(enemy.Attack(enemy.Spell));
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Enemy casts a {0}, hits hero for {1} dmg. Hero health is {2}", enemy.Spell.Name, enemy.Spell.Damage, this.hero.GetHealth());
                        }
                        else
                        {
                            enemyCurrentCol--;
                            Console.WriteLine("Enemy moves one square to the left in order to get to the hero. This is his move.");
                        }
                    }
                    else
                    {
                        enemyCurrentCol--;
                        Console.WriteLine("Enemy moves one square to the left in order to get to the hero. This is his move.");
                    }
                }
                else
                {
                    if (enemy.Spell != null)
                    {
                        if ((enemy.Spell.Damage >= enemy.Attack(enemy.Weapon) && enemy.CanCast()))
                        {
                            hero.TakeDamage(enemy.Attack(enemy.Spell));
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Enemy casts a {0}, hits hero for {1} dmg. Hero health is {2}", enemy.Spell.Name, enemy.Spell.Damage, this.hero.GetHealth());
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            hero.TakeDamage(enemy.Attack(enemy.Weapon));
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Enemy hits hero for {0} dmg. Hero health is {1}.", enemy.Attack(enemy.Weapon), this.hero.GetHealth());
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    else
                    {
                        hero.TakeDamage(enemy.Attack(enemy.Weapon));
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Enemy hits hero for {0} dmg. Hero health is {1}.", enemy.Attack(enemy.Weapon), this.hero.GetHealth());
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                if (!this.hero.IsAlive())
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Hero is dead!");
                    this.map[this.currentRow, this.currentCol] = '.';
                    bool canRespawn = this.Spawn(this.hero);
                    if (!canRespawn)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Game Over!");
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }
    }
}
