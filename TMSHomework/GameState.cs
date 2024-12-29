using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class GameState
    {
        public Player Player;
        public Field Field;
        public enum GameStatus { InProgress, Won, Lost };
        public GameStatus Status;
        Random Randomizer;

        public GameState(Player player, Field field)
        {
            Player = player;
            Field = field;
            Randomizer = new();
            Status = GameStatus.InProgress;
        }

        public void GenerateAdditionalItems()
        {
            if (Player.MoveCounter % GameOptions.StepToAddItems == 0 && Status == GameStatus.InProgress)
            {
                var itemCount = Randomizer.Next(GameOptions.MinItemAdd, GameOptions.MaxItemAdd + 1);
                var item = $"{GameOptions.BarrierChar}{GameOptions.TreasureChar}"[Randomizer.Next(0, 2)];
                Field.AddObjectsOnGameField(itemCount, item, Field.GameField);
            }
        }

        public void EndGame()
        {
            if (IsWon())
            {
                Status = GameStatus.Won;
            }
        }

        private bool IsWon() => !Field.GameField.SelectMany(ch => ch).Any(c => c == GameOptions.TreasureChar);
    }
}