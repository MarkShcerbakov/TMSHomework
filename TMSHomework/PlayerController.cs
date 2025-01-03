using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class PlayerController
    {
        public Player Player;
        public Field Field;
        public Dictionary<ConsoleKey, (int offsetY, int offsetX)> PlayersMoves;

        public PlayerController(Player player, Field field)
        {
            Field = field;
            Player = player;
            PlayersMoves = new()
            {
                [ConsoleKey.W] = (-1, 0),
                [ConsoleKey.S] = (1, 0),
                [ConsoleKey.A] = (0, -1),
                [ConsoleKey.D] = (0, 1),
            };
        }

        public void MovePlayer((int Y, int X) offsets)
        {
            Player.Bag += (Field.GameField[Player.PosY + offsets.Y][Player.PosX + offsets.X] == GameOptions.TreasureChar) ? 1 : 0;
            Field.GameField[Player.PosY + offsets.Y][Player.PosX + offsets.X] = GameOptions.PlayerChar;
            Field.GameField[Player.PosY][Player.PosX] = GameOptions.EmptyPlaceChar;
            Player.PosY += offsets.Y;
            Player.PosX += offsets.X;
            Player.MoveCounter++;
        }

        public bool IsPlayerMove((int Y, int X) offsets)
            => !$"{GameOptions.WallChar}{GameOptions.BarrierChar}".Contains(Field.GameField[Player.PosY + offsets.Y][Player.PosX + offsets.X]);
    }
}