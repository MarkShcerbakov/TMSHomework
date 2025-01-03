using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class GameOptions
    {
        public const char PlayerChar = 'P';
        public const char TreasureChar = 'T';
        public const char EmptyPlaceChar = '.';
        public const char WallChar = '@';
        public const char BarrierChar = '#';
        public const int StartBarrierCount = 5;
        public const int StartTreasureCount = 5;
        public const int StartPlayerCount = 1;
        public const int MinItemAdd = 1;
        public const int MaxItemAdd = 3;
        public const int StepToAddItems = 5;
    }
}
