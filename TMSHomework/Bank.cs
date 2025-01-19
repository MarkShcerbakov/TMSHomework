using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class Bank
    {
        public string Name { get; set; }
        public decimal Money { get; set; } = 0;
        public IProduct[] Products { get; set; }
        public Client[] Clients { get; set; }
        public BankWorkStatus Status { get; set; }

        public Bank(string name, int startMoney, IProduct[] products, Client[] clients)
        {
            Name = name;
            Money = startMoney;
            Products = products;
            Clients = clients;
            Status = BankWorkStatus.Working;
        }

        public Bank(string name, IProduct[] products, Client[] clients)
        {
            Name = name;
            Products = products;
            Clients = clients;
            Status = BankWorkStatus.Working;
        }

        public void Run()
        {
            Console.WriteLine($"Здравствуйте, Вас приветсвует {Name}!");
            var actionSelector = new ActionSelector(Products, Clients);
            var menuSelector = new MenuSelector();
            var menu = menuSelector.Roster.MainMenu;
            while (Status == BankWorkStatus.Working)
            {
                actionSelector.Roster.ShowMenu(menu);
                CheckInput(menu, out (int, string) selectedOption);
                if (IsClosed(selectedOption.Item2))
                {
                    Status = BankWorkStatus.Closed;
                    continue;
                }

                menu = menuSelector.GetMenu(selectedOption);
                actionSelector.GetAction(selectedOption);
            }

            Console.WriteLine("Спасибо за выбор нашего банка!");
        }

        public bool IsClosed(string text)
        {
            return text == "Выйти из банка";
        }

        public void CheckInput(Dictionary<int, (int, string)> menu, out (int, string) selectedOption)
        {
            while (!int.TryParse(Console.ReadLine(), out int choice) || !menu.TryGetValue(choice, out selectedOption))
            {
                Console.WriteLine("Введите корректное значение!");
            }
        }
    }

    public enum BankWorkStatus
    {
        Working,
        Closed
    }
}
