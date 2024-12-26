using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class MatrixBuilder
    {
        public static int[][] GetMatrix(List<string> input, int cols)
        {
            var tmpMatrix = input.Select(s => s.Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToArray();
            var correctCol = tmpMatrix.All(s => s.Length == cols);
            var correctValues = tmpMatrix.All(s => s.All(x => int.TryParse(x, out int _)));

            if (correctCol && correctValues)
            {
                return tmpMatrix.SelectMany(s => s.Select(int.Parse)).Chunk(cols).ToArray();
            }
            else
            {
                return null;
            }
        }
    }
}
