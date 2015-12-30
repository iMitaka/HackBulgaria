using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndLizards.Models
{
    public class Hero : ICharacter
    {
        private string name;
        private string title;
        private int health;
        private int currentHealth;
        private int mana;
        private int currentMana;
        private int manaRegenerationRate;
        private Weapon weapon;
        private Spell spell;
        private int attackPoints;

        public Hero(string name, string title, int health, int mana, int manaRegenerationRate) 
        {
            this.name = name;
            this.title = title;
            this.health = health;
            this.currentHealth = health;
            this.mana = mana;
            this.currentMana = mana;
            this.manaRegenerationRate = manaRegenerationRate;
            this.attackPoints = 0;
        }

        public string KnownAs() 
        {
            return string.Format("{0} the {1}", this.name, this.title);
        }

        public int GetHealth() 
        {
            return this.currentHealth;
        }

        public int GetMana() 
        {
            return this.currentMana;
        }

        public int ManaRegen
        {
            get 
            {
                return this.manaRegenerationRate;
            }
        }
        public bool IsAlive() 
        {
            if (this.currentHealth <= 0)
            {
                return false;
            }
            else 
            {
                return true;
            }
        }

        public bool CanCast() 
        {
            int manaNeeded = 0;
            if (this.Spell != null)
            {
                manaNeeded = this.Spell.ManaCost;
            }
            if (this.currentMana < manaNeeded)
            {
                return false;
            }
            else 
            {
                return true;
            }
        }

        public void TakeDamage(int damagePoints) 
        {
            this.currentHealth -= damagePoints;
            if (this.currentHealth < 0)
            {
                this.currentHealth = 0;
            }
        }

        public bool TakeHealing(int healingPoints) 
        {
            if (this.IsAlive() && this.GetHealth() < this.health)
            {
                this.currentHealth += healingPoints;
                if (this.currentHealth > this.health)
                {
                    this.currentHealth = this.health;
                }
                return true;
            }
            else 
            {
                return false;
            }
        }

        public bool TakeMana(int manaPoints) 
        {
            if (this.IsAlive() && this.GetMana() < this.mana)
            {
                this.currentMana += manaPoints;
                if (this.currentMana > this.mana)
                {
                    this.currentMana = mana;
                }
                return true;
            }
            else 
            {
                return false;
            }
        }


        public int Attack(Weapon weapon)
        {
            if (this.weapon == null)
            {
                return 0;
            }
            else 
            {
               return weapon.Damage;
            }

        }

        public int Attack(Spell spell)
        {
            if (spell == null)
            {
                return 0;
            }
            else
            {
                this.currentMana -= spell.ManaCost;
                return spell.Damage;
            }
        }

        public void Equip(Weapon weapon) 
        {
            this.weapon = weapon;
        }

        public Weapon Weapon 
        {
            get 
            {
                return this.weapon;
            }
        }

        public void Learn(Spell spell) 
        {
            this.spell = spell;
        }

        public Spell Spell 
        {
            get 
            {
                return this.spell;
            }
        }
    }
}
