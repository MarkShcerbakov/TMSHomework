namespace TMSHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(10, 10);
            game.DrawField();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey keyPressed = Console.ReadKey(true).Key;

                    if (keyPressed == ConsoleKey.Escape)
                    {
                        Console.SetCursorPosition(0, game.Rows + 6);
                        Console.WriteLine("Всего доброго! Спасибо за интерес к игре!");
                        break;
                    }
                    if (game.PlayersMoves.TryGetValue(keyPressed, out Func<bool> movePlayer))
                    {
                        game.MovePlayer(movePlayer());
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
