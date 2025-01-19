using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class MenuSelector
    {
        public MenuRoster Roster { get; set; }
        public Dictionary<int, Dictionary<int, (int, string)>> AllMenu { get; set; }

        public MenuSelector()
        {
            Roster = new();
            AllMenu = new()
            {
                [0] = Roster.MainMenu,
                [1] = Roster.ProductsMenu,
                [2] = Roster.ProductMenu,
                [3] = Roster.ClientsMenu,
                [4] = Roster.ClientMenu,
                [5] = Roster.ClientMenu,
                [6] = Roster.ClientMenu,
                [7] = Roster.ClientMenu
            };
        }

        public Dictionary<int, (int, string)> GetMenu((int, string) choice)
        {
            return AllMenu[choice.Item1];
        }
    }
}
