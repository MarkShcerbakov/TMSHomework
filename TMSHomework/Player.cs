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

        public Player(int posY, int posX)
        {
            PosY = posY;
            PosX = posX;
            Bag = 0;
        }
    }
}
