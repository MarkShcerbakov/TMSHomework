using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class Field
    {
        public char[][] GameField;
        public int Rows;
        public int Cols;
        public Random Randomizer;
        public int PlayerX;
        public int PlayerY;

        public Field(int rows, int cols, int playerY, int playerX)
        {
            Rows = rows;
            Cols = cols;
            PlayerX = playerX;
            PlayerY = playerY;
            Randomizer = new Random();
            GameField = GenerateField();
        }

        public char[][] GenerateField()
        {
            var field = new char[(Rows + 2) * (Cols + 2)].Select(ch => GameOptions.EmptyPlaceChar).Chunk(Cols + 2).ToArray();
            field = field.Select((ch, i) => i == 0 || i == Rows + 1 ? ch.Select(c => GameOptions.WallChar).ToArray()
                                                                    : ch.Select((c, j) => j == 0 || j == Cols + 1
                                                                    ? GameOptions.WallChar : c).ToArray()).ToArray();
            field[PlayerY][PlayerX] = GameOptions.PlayerChar;
            AddObjectsOnGameField(GameOptions.StartBarrierCount, GameOptions.BarrierChar, field);
            AddObjectsOnGameField(GameOptions.StartTreasureCount, GameOptions.TreasureChar, field);

            return field;
        }

        public void AddObjectsOnGameField(int count, char item, char[][] field)
        {
            int counter = 0;
            while (counter != count)
            {
                var itemXPos = Randomizer.Next(1, Rows + 1);
                var itemYPos = Randomizer.Next(1, Cols + 1);
                if (field[itemXPos][itemYPos] == GameOptions.EmptyPlaceChar)
                {
                    field[itemXPos][itemYPos] = item;
                    counter++;
                }
            }
        }

        public void DrawGameField()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int row = 0; row < Rows + 2; row++)
            {
                for (int col = 0; col < Cols + 2; col++)
                {
                    Console.Write(GameField[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}