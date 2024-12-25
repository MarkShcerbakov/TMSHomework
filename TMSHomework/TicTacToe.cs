using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class TicTacToe
    {
        public enum Mark
        {
            Empty,
            Cross,
            Circle
        }

        public enum GameResult
        {
            CrossWin,
            CircleWin,
            Draw
        }
        public static void Run(string description)
        {
            Console.WriteLine(description.Replace(" ", Environment.NewLine));
            Console.WriteLine(GetGameResult(CreateFromString(description)));
            Console.WriteLine();
        }

        private static Mark[,] CreateFromString(string str)
        {
            var field = str.Split(' ');
            var ans = new Mark[3, 3];
            for (int x = 0; x < field.Length; x++)
                for (var y = 0; y < field.Length; y++)
                    ans[x, y] = field[x][y] == 'X' ? Mark.Cross : (field[x][y] == 'O' ? Mark.Circle : Mark.Empty);
            return ans;
        }

        public static GameResult GetGameResult(Mark[,] field)
        {
            var arr = field.Cast<Mark>().Chunk(3).ToArray();
            var rowWin = RowColWin(arr);
            var colWin = RowColWin(RotateMatrixRight(arr));
            var diagonalWin = RowColWin(DiagonalWin(arr));
            var winner = new[] { rowWin.FirstOrDefault(new Mark[0]), colWin.FirstOrDefault(new Mark[0]), diagonalWin.FirstOrDefault(new Mark[0]) }.MaxBy(x => x.Length > 0);
            if (rowWin.Length > 1 || colWin.Length > 1)
            {
                return GameResult.Draw;
            }
            else if (winner.Length > 0)
            {
                return winner[0] == Mark.Cross ? GameResult.CrossWin : GameResult.CircleWin;
            }
            else
            {
                return GameResult.Draw;
            }
        }

        public static Mark[][] RowColWin(Mark[][] arr) => arr.Where(row => !row.Contains(Mark.Empty) && row.All(x => x == row[0])).ToArray();

        public static Mark[][] DiagonalWin(Mark[][] arr)
        {
            var leftDiagonal = new Mark[] { arr[0][0], arr[1][1], arr[2][2] };
            var rightDiagonal = new Mark[] { arr[0][2], arr[1][1], arr[2][0] };
            return new Mark[][] { leftDiagonal, rightDiagonal };
        }

        public static Mark[][] RotateMatrixRight(Mark[][] arr) => Enumerable.Range(0, arr[0].Length).Select(col => arr.Select(row => row[col]).Reverse().ToArray()).ToArray();
    }
}
