using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Models
{
    public abstract class Person
    {
        private string name;
        private Gender gender;
        public Person(string name, Gender gender) 
        {
            this.name = name;
            this.gender = gender;
        }
        public string Name() 
        {
            return name;
        }
        public Gender Gender() 
        {
            return this.gender;
        }

        public abstract string DailyStuff();
    }
}
