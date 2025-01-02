using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    public static class StringExtensions
    {
        public static int ToInt(this string s)
        {
            return int.Parse(s);
        }
    }
}
