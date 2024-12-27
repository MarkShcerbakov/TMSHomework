using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class GameDraw
    {
        public Game TheGame;
        public int OffsetY;

        public GameDraw(Game game)
        {
            TheGame = game;
        }

        public void DrawGameField()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int row = 0; row < TheGame.Rows + 2; row++)
            {
                for (int col = 0; col < TheGame.Cols + 2; col++)
                {
                    Console.Write(TheGame.Field[row][col]);
                }
                Console.WriteLine();
            }
            DrawGameInfo();
        }

        private void DrawGameInfo()
        {
            var offset = 0;
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(TheGame.Cols + 4, offset++);
            Console.WriteLine("TMS Lesson4-Task3-MiniGame");
            Console.SetCursorPosition(TheGame.Cols + 4, offset++);
            Console.WriteLine("Приложение моделирует систему управления виртуальным игровым пространством.");
            Console.SetCursorPosition(TheGame.Cols + 4, offset++);
            Console.WriteLine("В этом пространстве находятся клетки с разными объектами:");
            Console.SetCursorPosition(TheGame.Cols + 4, offset++);
            Console.WriteLine("(P - игрок, T - сокровище, # - стена, . - свободная клетка).");
            Console.SetCursorPosition(TheGame.Cols + 4, offset++);
            Console.WriteLine("Управление перемещением происходит клавишами W, A, S, D.");
            Console.SetCursorPosition(TheGame.Cols + 4, offset++);
            Console.WriteLine($"Каждые {TheGame.StepToAddItems} ходов на игровом поле будет появляться произвольное " +
                $"кол-во ({TheGame.MinItemAdd}-{TheGame.MaxItemAdd}) сокровищ или стен.");
            Console.SetCursorPosition(TheGame.Cols + 4, offset++);
            Console.WriteLine("Для выхода из приложения нажмите Esc.");
            Console.SetCursorPosition(TheGame.Cols + 4, ++offset);
            Console.WriteLine("Статистика игры:");
            Console.SetCursorPosition(TheGame.Cols + 4, offset++);
            Console.WriteLine($"Кол-во ходов: {TheGame.MoveCounter}");
            Console.SetCursorPosition(TheGame.Cols + 4, offset++);
            Console.WriteLine($"Кол-во собраных сокровищ: {TheGame.Player.Bag}");
            Console.SetCursorPosition(TheGame.Cols + 4, offset++);
            Console.WriteLine($"Кол-во сокровищ в игре: {TheGame.Field.SelectMany(ch => ch).Count(c => c == TheGame.TreasureChar)}");
            OffsetY = offset;
        }

        public void DrawEndGame()
        {
            var offset = 2;
            if (TheGame.IsWin)
            {
                Console.SetCursorPosition(0, Math.Max(TheGame.Rows + 2, OffsetY) + offset);
                Console.WriteLine("Поздравляю, Вы собрали все сокровища!");
                offset += 2;
            }
            Console.SetCursorPosition(0, Math.Max(TheGame.Rows + 2, OffsetY) + offset);
            Console.WriteLine("Всего доброго! Спасибо за интерес к игре!");
        }
    }
}
