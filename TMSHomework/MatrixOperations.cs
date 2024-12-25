using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class MatrixOperations
    {
        public static int[] NumberOfPositiveElements(int[][] arr) => arr.SelectMany(x => x).Where(x => x >= 0).ToArray();

        public static int[] NumberOfNegativeElements(int[][] arr) => arr.SelectMany(x => x).Where(x => x < 0).ToArray();

        public static int[][] SortRowsOfMatrix(int[][] arr) => arr.Select(x => x.OrderBy(y => y).ToArray()).ToArray();

        public static int[][] SortRowsOfMatrixDecending(int[][] arr) => arr.Select(x => x.OrderBy(y => -y).ToArray()).ToArray();

        public static int[][] SortMatrix(int[][] arr) => arr.SelectMany(x => x).OrderBy(x => x).Chunk(arr[0].Length).ToArray();

        public static int[][] SortMatrixDescending(int[][] arr) => arr.SelectMany(x => x).OrderBy(x => -x).Chunk(arr[0].Length).ToArray();

        public static int[][] InverseRowsOfMatrix(int[][] arr) => arr.Select(x => x.Reverse().ToArray()).ToArray();

        public static int[][] InverseMatrix(int[][] arr) => arr.SelectMany(x => x).Reverse().Chunk(arr[0].Length).ToArray();

        public static long MatrixDeterminant(int[][] matrix)
        {
            if (matrix.Length < 2)
            {
                return matrix[0][0];
            }
            if (matrix.Length == 2)
            {
                return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
            }

            long det = 0;
            for (int j = 0; j < matrix.Length; j++)
            {
                var smallMatrix = matrix[1..].Select(x => x.Where((_, i) => i != j).ToArray()).ToArray();
                det += matrix[0][j] * MatrixDeterminant(smallMatrix) * (j % 2 == 0 ? 1 : -1);
            }

            return det;
        }

        public static void MatrixDisplay(int[][] arr)
        {
            var rows = arr.Length;
            var cols = arr[0].Length;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{arr[row][col],5:d}");
                }
                Console.WriteLine();
            }
        }
    }
}
