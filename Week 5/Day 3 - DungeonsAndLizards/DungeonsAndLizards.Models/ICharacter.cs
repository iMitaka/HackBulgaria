using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndLizards.Models
{
    public interface ICharacter
    {
        bool IsAlive();
        bool CanCast();
        int GetHealth();
        int GetMana();
        bool TakeHealing(int healingPoints);
        bool TakeMana(int manaPoints);
        int Attack(Weapon weapon);
        int Attack(Spell spell);
        void TakeDamage(int damage);
    }
}
