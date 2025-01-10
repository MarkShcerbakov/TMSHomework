using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    public class Dog : AnimalBase
    {
        public string Name { get; private set; }

        public override void Eat()
        {
            Console.WriteLine($"Собака {Name} ест!");
        }

        public override string GetName()
        {
            return Name;
        }

        public override void SetName(string name)
        {
            Name = name;
        }
    }
}
