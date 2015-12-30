using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndLizards.Models
{
    public class Enemy : ICharacter
    {
        private int health;
        private int currentHealth;
        private int mana;
        private int baseDamage;
        private Weapon weapon;
        private Spell spell;

        public Enemy(int health, int mana, int baseDamage) 
        {
            this.health = health;
            this.currentHealth = health;
            this.mana = mana;
            this.baseDamage = baseDamage;
        }

        public bool IsAlive()
        {
            if (this.currentHealth > 0)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public bool CanCast()
        {
            int manaNeeded = 0;
            if (this.Spell != null)
            {
                manaNeeded = this.Spell.ManaCost;
            }
            if (this.mana < manaNeeded)
            {
                return false;
            }
            else 
            {
                return true;
            }
        }

        public int GetHealth()
        {
            return this.currentHealth;
        }

        public int GetMana()
        {
            return this.mana;
        }

        public bool TakeHealing(int healingPoints)
        {
            if (this.currentHealth > this.health)
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
            throw new NotImplementedException();
        }

        public int Attack(Weapon weapon)
        {
            if (this.weapon == null)
            {
                return this.baseDamage;
            }
            else 
            {
                return weapon.Damage;
            }
        }

        public Weapon Weapon 
        {
            get 
            {
                return this.weapon;
            }
        }

        public Spell Spell 
        {
            get 
            {
                return this.spell;
            }
            set 
            {
                this.spell = value;
            }
        }

        public int Attack(Spell spell)
        {
            if (this.spell == null)
            {
                return this.baseDamage;
            }
            else 
            {
                this.mana -= this.spell.ManaCost;
                return spell.Damage;
            }
        }

        public void TakeDamage(int damage)
        {
            this.currentHealth -= damage;
            if (this.currentHealth < 0)
            {
                this.currentHealth = 0;
            }
        }
    }
}
