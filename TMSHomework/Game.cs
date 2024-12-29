using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class Game
    {
        public readonly char PlayerChar = 'P';
        public readonly char TreasureChar = 'T';
        public readonly char EmptyPlaceChar = '.';
        public readonly char WallChar = '@';
        public readonly char BarrierChar = '#';
        public readonly int StartBarrierCount = 5;
        public readonly int StartTreasureCount = 5;
        public readonly int StartPlayerCount = 1;
        public readonly int StepToAddItems = 5;
        public int Rows;
        public int Cols;
        public char[][] Field;
        public Dictionary<ConsoleKey, (int offsetY, int offsetX)> PlayersMoves;
        public Player Player;
        public int MoveCounter;
        public readonly int MinItemAdd = 1;
        public readonly int MaxItemAdd = 3;
        public Random Randomizer;
        public enum GameStatus { InProgress, Won, Lost };
        public GameStatus Status { get; private set; }

        public Game(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Randomizer = new();
            Field = GenerateField();
            Player = GetStartPlayerPosition();
            PlayersMoves = new()
            {
                [ConsoleKey.W] = (-1, 0),
                [ConsoleKey.S] = (1, 0),
                [ConsoleKey.A] = (0, -1),
                [ConsoleKey.D] = (0, 1),
            };
            MoveCounter = 0;
            Status = GameStatus.InProgress;
        }

        public char[][] GenerateField()
        {
            // Генерируем пустой массив Rows x Cols
            var field = new char[(Rows + 2) * (Cols + 2)].Select(ch => EmptyPlaceChar).Chunk(Cols + 2).ToArray();

            // Окружаем игровое поле стенами @
            field = field.Select((ch, i) => i == 0 || i == Rows + 1 ? ch.Select(c => WallChar).ToArray()
                                                                    : ch.Select((c, j) => j == 0 || j == Cols + 1 ? WallChar : c).ToArray()).ToArray();
            // Размещаем объекты на игровом поле
            AddObjectsOnGameField(StartBarrierCount, BarrierChar, field);
            AddObjectsOnGameField(StartTreasureCount, TreasureChar, field);
            AddObjectsOnGameField(StartPlayerCount, PlayerChar, field);

            return field;
        }

        public void AddObjectsOnGameField(int count, char item, char[][] field)
        {
            int counter = 0;
            while (counter != count)
            {
                var itemXPos = Randomizer.Next(1, Rows + 1);
                var itemYPos = Randomizer.Next(1, Cols + 1);
                if (field[itemXPos][itemYPos] == EmptyPlaceChar)
                {
                    field[itemXPos][itemYPos] = item;
                    counter++;
                }
                else
                {
                    continue;
                }
            }
        }

        private Player GetStartPlayerPosition()
        {
            var playersPos = Array.IndexOf(Field.SelectMany(ch => ch).ToArray(), PlayerChar);
            var yPos = playersPos / (Cols + 2);
            var xPos = playersPos % (Cols + 2);
            return new Player(yPos, xPos);
        }

        public void MovePlayer((int Y, int X) offsets)
        {
            if (Field[Player.PosY + offsets.Y][Player.PosX + offsets.X] == TreasureChar)
            {
                Player.Bag++;
            }

            Field[Player.PosY + offsets.Y][Player.PosX + offsets.X] = PlayerChar;
            Field[Player.PosY][Player.PosX] = EmptyPlaceChar;
            Player.PosY += offsets.Y;
            Player.PosX += offsets.X;
            MoveCounter++;

            if (IsEndGame())
            {
                Status = GameStatus.Won;
                return;
            }
            else
            {
                GenerateAdditionalItems();
            }
        }

        public bool IsPlayerMove((int Y, int X) offsets)
        {
            if (!$"{WallChar}{BarrierChar}".Contains(Field[Player.PosY + offsets.Y][Player.PosX + offsets.X]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GenerateAdditionalItems()
        {
            if (MoveCounter % StepToAddItems == 0)
            {
                var itemCount = Randomizer.Next(MinItemAdd, MaxItemAdd + 1);
                var item = $"{BarrierChar}{TreasureChar}"[Randomizer.Next(0, 2)];
                AddObjectsOnGameField(itemCount, item, Field);
            }
        }

        private bool IsEndGame() => !Field.SelectMany(ch => ch).Any(c => c == TreasureChar);
    }
}