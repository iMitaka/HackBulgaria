using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animals.Models;

namespace Animals
{
    public class TestHierarchyApp
    {
        public static void Main()
        {
            List<ILandAnimal> landAnimals = new List<ILandAnimal>();
            landAnimals.Add(new Cat());
            landAnimals.Add(new Dog());

            foreach (var animal in landAnimals)
            {
                Console.WriteLine(animal.Greet());
            }
            Console.WriteLine();

            List<Animal> animals = new List<Animal>();
            animals.Add(new Dog());
            animals.Add(new Cat());
            animals.Add(new Owl());
            animals.Add(new Shark());
            animals.Add(new Crocodile());

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.Move());
            }
        }
    }
}
