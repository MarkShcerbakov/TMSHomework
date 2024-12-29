using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class Player
    {
        public int PosX { get; set; }

        public int PosY { get; set; }

        public int Bag { get; set; }

        public int MoveCounter { get; set; }

        public Random Randomiser;

        public Player(int rows, int cols)
        {
            Randomiser = new Random();
            PosY = Randomiser.Next(1, rows + 1);
            PosX = Randomiser.Next(1, cols + 1);
            Bag = 0;
            MoveCounter = 0;
        }
    }
}
