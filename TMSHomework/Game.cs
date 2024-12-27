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
        public Dictionary<ConsoleKey, Func<bool>> PlayersMoves;
        public Player Player;
        public int MoveCounter;
        public bool IsGameContinue;
        public bool IsWin;
        public readonly int MinItemAdd = 1;
        public readonly int MaxItemAdd = 3;

        public Game(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Field = GenerateField();
            Player = GetStartPlayerPosition();
            PlayersMoves = new()
            {
                [ConsoleKey.W] = MovePlayerUp,
                [ConsoleKey.S] = MovePlayerDown,
                [ConsoleKey.A] = MovePlayerLeft,
                [ConsoleKey.D] = MovePlayerRight,
            };
            MoveCounter = 0;
            IsGameContinue = true;
            IsWin = false;
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
                var itemXPos = new Random().Next(1, Rows + 1);
                var itemYPos = new Random().Next(1, Cols + 1);
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

        public void MovePlayer(bool isMove)
        {
            if (isMove)
            {
                MoveCounter++;
                if (IsEndGame())
                {
                    IsWin = true;
                    IsGameContinue = false;
                    return;
                }
                else
                {
                    GenerateAdditionalItems();
                }
            }
        }

        private bool MovePlayerUp()
        {
            if (Player.PosY > 1 && !$"{BarrierChar}{WallChar}".Contains(Field[Player.PosY - 1][Player.PosX]))
            {
                if (Field[Player.PosY - 1][Player.PosX] == EmptyPlaceChar)
                {
                    (Field[Player.PosY - 1][Player.PosX], Field[Player.PosY][Player.PosX]) =
                        (Field[Player.PosY][Player.PosX], Field[Player.PosY - 1][Player.PosX]);
                }
                if (Field[Player.PosY - 1][Player.PosX] == TreasureChar)
                {
                    Field[Player.PosY - 1][Player.PosX] = PlayerChar;
                    Field[Player.PosY][Player.PosX] = EmptyPlaceChar;
                    Player.Bag++;
                }
                Player.PosY--;
                return true;
            }

            return false;
        }

        private bool MovePlayerDown()
        {
            if (Player.PosY < Rows + 1 && !$"{BarrierChar}{WallChar}".Contains(Field[Player.PosY + 1][Player.PosX]))
            {
                if (Field[Player.PosY + 1][Player.PosX] == EmptyPlaceChar)
                {
                    (Field[Player.PosY + 1][Player.PosX], Field[Player.PosY][Player.PosX]) =
                        (Field[Player.PosY][Player.PosX], Field[Player.PosY + 1][Player.PosX]);
                }
                if (Field[Player.PosY + 1][Player.PosX] == TreasureChar)
                {
                    Field[Player.PosY + 1][Player.PosX] = PlayerChar;
                    Field[Player.PosY][Player.PosX] = EmptyPlaceChar;
                    Player.Bag++;
                }
                Player.PosY++;
                return true;
            }

            return false;
        }

        private bool MovePlayerLeft()
        {
            if (Player.PosX > 1 && !$"{BarrierChar}{WallChar}".Contains(Field[Player.PosY][Player.PosX - 1]))
            {
                if (Field[Player.PosY][Player.PosX - 1] == EmptyPlaceChar)
                {
                    (Field[Player.PosY][Player.PosX - 1], Field[Player.PosY][Player.PosX]) =
                        (Field[Player.PosY][Player.PosX], Field[Player.PosY][Player.PosX - 1]);
                }
                if (Field[Player.PosY][Player.PosX - 1] == TreasureChar)
                {
                    Field[Player.PosY][Player.PosX - 1] = PlayerChar;
                    Field[Player.PosY][Player.PosX] = EmptyPlaceChar;
                    Player.Bag++;
                }
                Player.PosX--;
                return true;
            }

            return false;
        }

        private bool MovePlayerRight()
        {
            if (Player.PosX < Cols + 1 && !$"{BarrierChar}{WallChar}".Contains(Field[Player.PosY][Player.PosX + 1]))
            {
                if (Field[Player.PosY][Player.PosX + 1] == EmptyPlaceChar)
                {
                    (Field[Player.PosY][Player.PosX + 1], Field[Player.PosY][Player.PosX]) =
                        (Field[Player.PosY][Player.PosX], Field[Player.PosY][Player.PosX + 1]);
                }
                if (Field[Player.PosY][Player.PosX + 1] == TreasureChar)
                {
                    Field[Player.PosY][Player.PosX + 1] = PlayerChar;
                    Field[Player.PosY][Player.PosX] = EmptyPlaceChar;
                    Player.Bag++;
                }
                Player.PosX++;
                return true;
            }

            return false;
        }

        public void GenerateAdditionalItems()
        {
            if (MoveCounter % StepToAddItems == 0)
            {
                var itemCount = new Random().Next(MinItemAdd, MaxItemAdd + 1);
                var item = $"{BarrierChar}{TreasureChar}"[new Random().Next(0, 2)];
                AddObjectsOnGameField(itemCount, item, Field);
            }
        }

        private bool IsEndGame() => !Field.SelectMany(ch => ch).Any(c => c == TreasureChar);
    }
}