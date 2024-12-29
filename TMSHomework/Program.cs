namespace TMSHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TMS Lesson4-Task3-MiniGame");
            Console.WriteLine("Приложение моделирует систему управления виртуальным игровым пространством.");
            Console.WriteLine("В этом пространстве находятся клетки с разными объектами:");
            Console.WriteLine("(P - игрок, T - сокровище, # - стена, . - свободная клетка).");
            Console.WriteLine("Управление перемещением происходит клавишами W, A, S, D.");
            Console.WriteLine("Каждые 5 ходов на игровом поле будет появляться произвольное кол-во (1-3) сокровищ или стен.");

            int rows, cols;
            Console.WriteLine("\nВведите кол-во строк игрового поля(5-20):");
            while (!int.TryParse(Console.ReadLine(), out rows) || rows < 5 || rows > 20)
            {
                Console.WriteLine("Введите корректное значение кол-во строк!");
            }
            Console.WriteLine("\nВведите кол-во столбцов игрового поля(5-20):");
            while (!int.TryParse(Console.ReadLine(), out cols) || cols < 5 || cols > 20)
            {
                Console.WriteLine("Введите корректное значение кол-во строк!");
            }

            var player = new Player(rows, cols);
            var field = new Field(rows, cols, player.PosY, player.PosX);
            var playerController = new PlayerController(player, field);
            var gameState = new GameState(player, field);
            var gameDraw = new GameDraw(gameState);
            field.DrawGameField();
            gameDraw.DrawGameInfo();
            while (gameState.Status == GameState.GameStatus.InProgress)
            {
                if (Console.KeyAvailable)
                {
                    var keyPressed = Console.ReadKey(true).Key;

                    if (keyPressed == ConsoleKey.Escape)
                    {
                        break;
                    }
                    if (playerController.PlayersMoves.TryGetValue(keyPressed, out (int, int) movePlayer))
                    {
                        // Если игрок совершил движение
                        if (playerController.IsPlayerMove(movePlayer))
                        {
                            playerController.MovePlayer(movePlayer);
                            gameState.EndGame();
                            gameState.GenerateAdditionalItems();
                            field.DrawGameField();
                            gameDraw.DrawGameInfo();
                        }
                    }
                }
            }

            gameDraw.DrawEndGame();
            Console.ReadKey();
        }
    }
}
