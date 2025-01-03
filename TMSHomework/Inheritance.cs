using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class Inheritance
    {
        public static void Print(params object[] objects) => Console.WriteLine(string.Join(", ", objects));

        public static object[] Combine(params object[] arrays)
        {
            if (arrays.Length == 0) return null;
            var elementType = arrays[0].GetType().GetElementType();
            var checkType = arrays.All(array => array.GetType().GetElementType() == elementType);
            if (checkType)
            {
                return arrays.Aggregate(new object[0], (acc, nxt) => acc.Concat((nxt as Array).Cast<object>()).ToArray());
            }
            else
            {
                return null;
            }
        }

        public static object MiddleOfThree(params object[] arr) => arr.OrderBy(x => x).ElementAt(1);

        public static object Min(Array arr)
        {
            Array.Sort(arr);
            return arr.GetValue(0);
        }
    }
}
