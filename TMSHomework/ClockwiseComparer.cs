using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class ClockwiseComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            var pointOne = (Point)x;
            var pointTwo = (Point)y;
            var atanOne = -Math.Atan2(pointOne.Y, -pointOne.X);
            var atanTwo = -Math.Atan2(pointTwo.Y, -pointTwo.X);
            return atanOne.CompareTo(atanTwo);
        }
    }
}
