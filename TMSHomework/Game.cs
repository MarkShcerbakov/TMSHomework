using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class Game
    {
        private static char _playerChar = 'P';
        private static char _treasureChar = 'T';
        private static char _emptyPlaceChar = '.';
        private static char _wallChar = '@';
        private static char _barrierChar = '#';
        private static int _startBarrierCount = 5;
        private static int _startTreasureCount = 5;
        private static int _startPlayerCount = 1;
        private static int _stepToAddItems = 5;
        public int Rows;
        public int Cols;
        public char[][] Field;
        public Dictionary<ConsoleKey, Func<bool>> PlayersMoves;
        public Player Player;
        public int MoveCounter;

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
        }

        public char[][] GenerateField()
        {
            // Генерируем пустой массив Rows x Cols
            var field = new char[(Rows + 2) * (Cols + 2)].Select(ch => _emptyPlaceChar).Chunk(Cols + 2).ToArray();

            // Окружаем игровое поле стенами @
            field = field.Select((ch, i) => i == 0 || i == Rows + 1 ? ch.Select(c => _wallChar).ToArray()
                                                                    : ch.Select((c, j) => j == 0 || j == Cols + 1 ? _wallChar : c).ToArray()).ToArray();

            // Размещаем объекты на игровом поле
            AddObjectsOnGameField(_startBarrierCount, _barrierChar, field);
            AddObjectsOnGameField(_startTreasureCount, _treasureChar, field);
            AddObjectsOnGameField(_startPlayerCount, _playerChar, field);

            return field;
        }

        public void AddObjectsOnGameField(int count, char item, char[][] field)
        {
            int counter = 0;
            while (counter != count)
            {
                var itemXPos = new Random().Next(1, Rows + 1);
                var itemYPos = new Random().Next(1, Cols + 1);
                if (field[itemXPos][itemYPos] == _emptyPlaceChar)
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
            var playersPos = Array.IndexOf(Field.SelectMany(ch => ch).ToArray(), _playerChar);
            var yPos = playersPos / (Cols + 2);
            var xPos = playersPos % (Cols + 2);
            return new Player(yPos, xPos);
        }

        public void MovePlayer(bool isMove)
        {
            if (isMove)
            {
                MoveCounter++;
                DrawField();
                if (IsEndGame())
                {
                    Console.SetCursorPosition(0, Rows + 4);
                    Console.WriteLine("Поздравляю, вы собрали все сокровища!");
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
            if (Player.PosY > 1 && !$"{_barrierChar}{_wallChar}".Contains(Field[Player.PosY - 1][Player.PosX]))
            {
                if (Field[Player.PosY - 1][Player.PosX] == _emptyPlaceChar)
                {
                    (Field[Player.PosY - 1][Player.PosX], Field[Player.PosY][Player.PosX]) =
                        (Field[Player.PosY][Player.PosX], Field[Player.PosY - 1][Player.PosX]);
                }
                if (Field[Player.PosY - 1][Player.PosX] == _treasureChar)
                {
                    Field[Player.PosY - 1][Player.PosX] = _playerChar;
                    Field[Player.PosY][Player.PosX] = _emptyPlaceChar;
                    Player.Bag++;
                }
                Player.PosY--;
                return true;
            }

            return false;
        }

        private bool MovePlayerDown()
        {
            if (Player.PosY < Rows + 1 && !$"{_barrierChar}{_wallChar}".Contains(Field[Player.PosY + 1][Player.PosX]))
            {
                if (Field[Player.PosY + 1][Player.PosX] == _emptyPlaceChar)
                {
                    (Field[Player.PosY + 1][Player.PosX], Field[Player.PosY][Player.PosX]) =
                        (Field[Player.PosY][Player.PosX], Field[Player.PosY + 1][Player.PosX]);
                }
                if (Field[Player.PosY + 1][Player.PosX] == _treasureChar)
                {
                    Field[Player.PosY + 1][Player.PosX] = _playerChar;
                    Field[Player.PosY][Player.PosX] = _emptyPlaceChar;
                    Player.Bag++;
                }
                Player.PosY++;
                return true;
            }

            return false;
        }

        private bool MovePlayerLeft()
        {
            if (Player.PosX > 1 && !$"{_barrierChar}{_wallChar}".Contains(Field[Player.PosY][Player.PosX - 1]))
            {
                if (Field[Player.PosY][Player.PosX - 1] == _emptyPlaceChar)
                {
                    (Field[Player.PosY][Player.PosX - 1], Field[Player.PosY][Player.PosX]) =
                        (Field[Player.PosY][Player.PosX], Field[Player.PosY][Player.PosX - 1]);
                }
                if (Field[Player.PosY][Player.PosX - 1] == _treasureChar)
                {
                    Field[Player.PosY][Player.PosX - 1] = _playerChar;
                    Field[Player.PosY][Player.PosX] = _emptyPlaceChar;
                    Player.Bag++;
                }
                Player.PosX--;
                return true;
            }

            return false;
        }

        private bool MovePlayerRight()
        {
            if (Player.PosX < Cols + 1 && !$"{_barrierChar}{_wallChar}".Contains(Field[Player.PosY][Player.PosX + 1]))
            {
                if (Field[Player.PosY][Player.PosX + 1] == _emptyPlaceChar)
                {
                    (Field[Player.PosY][Player.PosX + 1], Field[Player.PosY][Player.PosX]) =
                        (Field[Player.PosY][Player.PosX], Field[Player.PosY][Player.PosX + 1]);
                }
                if (Field[Player.PosY][Player.PosX + 1] == _treasureChar)
                {
                    Field[Player.PosY][Player.PosX + 1] = _playerChar;
                    Field[Player.PosY][Player.PosX] = _emptyPlaceChar;
                    Player.Bag++;
                }
                Player.PosX++;
                return true;
            }

            return false;
        }

        public void DrawField()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int row = 0; row < Rows + 2; row++)
            {
                for (int col = 0; col < Cols + 2; col++)
                {
                    Console.Write(Field[row][col]);
                }
                Console.WriteLine();
            }
            DrawGameInfo();
        }

        private void DrawGameInfo()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(Cols + 4, 0);
            Console.WriteLine("TMS Lesson4-Task3-MiniGame");
            Console.SetCursorPosition(Cols + 4, 1);
            Console.WriteLine("Приложение моделирует систему управления виртуальным игровым пространством.");
            Console.SetCursorPosition(Cols + 4, 2);
            Console.WriteLine("В этом пространстве находятся клетки с разными объектами:");
            Console.SetCursorPosition(Cols + 4, 3);
            Console.WriteLine("(P - игрок, T - сокровище, # - стена, . - свободная клетка).");
            Console.SetCursorPosition(Cols + 4, 4);
            Console.WriteLine("Управление перемещением происходит клавишами W, A, S, D.");
            Console.SetCursorPosition(Cols + 4, 5);
            Console.WriteLine("Для выхода из приложения нажмите Esc.");
            Console.SetCursorPosition(Cols + 4, 7);
            Console.WriteLine("Статистика игры:");
            Console.SetCursorPosition(Cols + 4, 8);
            Console.WriteLine($"Кол-во ходов: {MoveCounter}");
            Console.SetCursorPosition(Cols + 4, 9);
            Console.WriteLine($"Кол-во собраных сокровищ: {Player.Bag}");
            Console.SetCursorPosition(Cols + 4, 10);
            Console.WriteLine($"Кол-во сокровищ в игре: {Field.SelectMany(ch => ch).Count(c => c == _treasureChar)}");
        }

        public void GenerateAdditionalItems()
        {
            if (MoveCounter % _stepToAddItems == 0)
            {
                var objCount = new Random().Next(1, 4);
                var item = $"{_barrierChar}{_treasureChar}"[new Random().Next(0, 2)];
                AddObjectsOnGameField(objCount, item, Field);
                DrawField();
            }
        }

        private bool IsEndGame() => !Field.SelectMany(ch => ch).Any(c => c == _treasureChar);
    }
}
