using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    public abstract class AnimalBase
    {
        public string Name { get; private set; }

        public abstract void SetName(string name);

        public abstract string GetName();

        public abstract void Eat();
    }
}
