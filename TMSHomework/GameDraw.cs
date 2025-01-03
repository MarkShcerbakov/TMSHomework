using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class GameDraw
    {
        public GameState TheGame;
        public int OffsetY;

        public GameDraw(GameState game)
        {
            TheGame = game;
        }

        public void DrawGameInfo()
        {
            var offset = 0;
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(TheGame.Field.Cols + 4, offset++);
            Console.WriteLine("TMS Lesson4-Task3-MiniGame");
            Console.SetCursorPosition(TheGame.Field.Cols + 4, offset++);
            Console.WriteLine("Приложение моделирует систему управления виртуальным игровым пространством.");
            Console.SetCursorPosition(TheGame.Field.Cols + 4, offset++);
            Console.WriteLine("В этом пространстве находятся клетки с разными объектами:");
            Console.SetCursorPosition(TheGame.Field.Cols + 4, offset++);
            Console.WriteLine("(P - игрок, T - сокровище, # - стена, . - свободная клетка).");
            Console.SetCursorPosition(TheGame.Field.Cols + 4, offset++);
            Console.WriteLine("Управление перемещением происходит клавишами W, A, S, D.");
            Console.SetCursorPosition(TheGame.Field.Cols + 4, offset++);
            Console.WriteLine($"Каждые {GameOptions.StepToAddItems} ходов на игровом поле будет появляться произвольное " +
                $"кол-во ({GameOptions.MinItemAdd}-{GameOptions.MaxItemAdd}) сокровищ или стен.");
            Console.SetCursorPosition(TheGame.Field.Cols + 4, offset++);
            Console.WriteLine("Для выхода из приложения нажмите Esc.");
            Console.SetCursorPosition(TheGame.Field.Cols + 4, ++offset);
            Console.WriteLine("Статистика игры:");
            Console.SetCursorPosition(TheGame.Field.Cols + 4, offset++);
            Console.WriteLine($"Кол-во ходов: {TheGame.Player.MoveCounter}");
            Console.SetCursorPosition(TheGame.Field.Cols + 4, offset++);
            Console.WriteLine($"Кол-во собраных сокровищ: {TheGame.Player.Bag}");
            Console.SetCursorPosition(TheGame.Field.Cols + 4, offset++);
            Console.WriteLine($"Кол-во сокровищ в игре: {TheGame.Field.GameField.SelectMany(ch => ch).Count(c => c == GameOptions.TreasureChar)}");
            OffsetY = offset;
        }

        public void DrawEndGame()
        {
            var offset = 2;
            if (TheGame.Status == GameState.GameStatus.Won)
            {
                Console.SetCursorPosition(0, Math.Max(TheGame.Field.Rows + 2, OffsetY) + offset);
                Console.WriteLine("Поздравляю, Вы собрали все сокровища!");
                offset += 2;
            }
            Console.SetCursorPosition(0, Math.Max(TheGame.Field.Rows + 2, OffsetY) + offset);
            Console.WriteLine("Всего доброго! Спасибо за интерес к игре!");
        }
    }
}
