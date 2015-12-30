using Persons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    public class PersonTestApp
    {
        public static void Main()
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Adult("Ivan",Gender.male));
            persons.Add(new Children("IvanJunior", Gender.male));

            foreach (var person in persons)
            {
                Console.WriteLine(person.ToString());
            }
            Console.WriteLine();
            var Pesho = new Adult("Pesho", Gender.male);
            var PeshoJunior = new Children("PeshoJunior", Gender.male);
            var PeshoToy = new Toy() { Color = "Green", Size = 10 };
            Console.WriteLine(PeshoToy.ToString());
            Console.WriteLine();
            Console.WriteLine(Pesho.ToString());
            Console.WriteLine();
            Console.WriteLine(PeshoJunior.ToString());
            Console.WriteLine();
            
            Pesho.Childrens.Add(PeshoJunior);
            PeshoJunior.Toys.Add(PeshoToy);
            Pesho.isBooring = true;
            
            Console.WriteLine(Pesho.ToString());
            foreach (var child in Pesho.Childrens)
            {
                Console.WriteLine(child.ToString());
                foreach (var toy in child.Toys)
                {
                    Console.WriteLine(toy.ToString());
                }
            }
            Console.WriteLine();
            if (Pesho.isBooring)
            {
                Console.WriteLine("Golqma skukaa brat..!");
            }
        }
    }
}
