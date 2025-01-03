using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class Book : IComparable
    {
        public string Title;
        public int Theme;

        public int CompareTo(object? obj)
        {
            if (obj is Book)
            {
                var comparer = Theme.CompareTo(((Book)obj).Theme);
                return comparer != 0 ? comparer : Title.CompareTo(((Book)obj).Title);
            }
            else
            {
                throw new InvalidCastException();
            }
        }
    }
}
