using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class MatrixOperations
    {
        private static Dictionary<int, Func<int[][], Array>> _operations = new()
        {
            [1] = NumberOfPositiveElements,
            [2] = NumberOfNegativeElements,
            [3] = SortRowsOfMatrix,
            [4] = SortRowsOfMatrixDecending,
            [5] = SortMatrix,
            [6] = SortMatrixDescending,
            [7] = InverseRowsOfMatrix,
            [8] = InverseMatrix,
            [9] = MatrixDeterminant
        };

        public static Func<int[][], Array> GetOperator(int choice) => _operations.TryGetValue(choice, out Func<int[][], Array> operation) ? operation : null;

        public static int[] NumberOfPositiveElements(int[][] arr) => arr.SelectMany(x => x).Where(x => x >= 0).ToArray();

        public static int[] NumberOfNegativeElements(int[][] arr) => arr.SelectMany(x => x).Where(x => x < 0).ToArray();

        public static int[][] SortRowsOfMatrix(int[][] arr) => arr.Select(x => x.OrderBy(y => y).ToArray()).ToArray();

        public static int[][] SortRowsOfMatrixDecending(int[][] arr) => arr.Select(x => x.OrderBy(y => -y).ToArray()).ToArray();

        public static int[][] SortMatrix(int[][] arr) => arr.SelectMany(x => x).OrderBy(x => x).Chunk(arr[0].Length).ToArray();

        public static int[][] SortMatrixDescending(int[][] arr) => arr.SelectMany(x => x).OrderBy(x => -x).Chunk(arr[0].Length).ToArray();

        public static int[][] InverseRowsOfMatrix(int[][] arr) => arr.Select(x => x.Reverse().ToArray()).ToArray();

        public static int[][] InverseMatrix(int[][] arr) => arr.SelectMany(x => x).Reverse().Chunk(arr[0].Length).ToArray();

        public static long[] MatrixDeterminant(int[][] matrix)
        {
            if (matrix.Length != matrix[0].Length)
            {
                return new long[0];
            }
            if (matrix.Length < 2)
            {
                return new long[] { matrix[0][0] };
            }
            if (matrix.Length == 2)
            {
                return new long[] { matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0] };
            }

            long determinant = 0;
            for (int j = 0; j < matrix.Length; j++)
            {
                var smallMatrix = matrix[1..].Select(x => x.Where((_, i) => i != j).ToArray()).ToArray();
                var sign = j % 2 == 0 ? 1 : -1;
                var smallMatrixDeterminant = MatrixDeterminant(smallMatrix)[0];
                determinant += matrix[0][j] * smallMatrixDeterminant * sign;
            }

            return new long[] { determinant };
        }

        public static void MatrixDisplay(Array arr)
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("-");
                return;
            }
            if (arr.GetValue(0) is not Array)
            {
                foreach (var row in arr)
                {
                    Console.Write($"{row,5:d}");
                }
            }
            else
            {
                foreach (var row in arr)
                {
                    MatrixDisplay((Array)row);
                    Console.WriteLine();
                }
            }
        }
    }
}
