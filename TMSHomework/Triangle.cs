using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class Triangle
    {
        public Point A;
        public Point B;
        public Point C;

        public override string ToString()
        {
            return $"({A}) ({B}) ({C})";
        }
    }
}
