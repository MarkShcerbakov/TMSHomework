using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class ActionSelector
    {
        public delegate void MethodSelector();
        public Dictionary<int, MethodSelector> Actions { get; set; }
        public ActionRoster Roster { get; set; }
        public ActionSelector(IProduct[] products, Client[] clients)
        {
            Roster = new(products, clients);
            Actions = new()
            {
                [1] = Roster.ShowProducts,
                [2] = Roster.ShowProduct,
                [3] = Roster.ShowClients,
                [4] = Roster.ShowClient,
                [5] = Roster.RemoveProductFromClient,
                [6] = Roster.AddProductToClient
            };
        }

        public void GetAction((int, string) selectedOption)
        {
            if (Actions.TryGetValue(selectedOption.Item1, out MethodSelector methodSelector))
            {
                methodSelector();
            }
        }
    }
}
