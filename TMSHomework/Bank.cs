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
        public MenuSelector Menu { get; set; }

        public Bank(string name, int startMoney, IProduct[] products, Client[] clients)
        {
            Name = name;
            Money = startMoney;
            Products = products;
            Clients = clients;
            Status = BankWorkStatus.Working;
            Menu = new();
        }

        public Bank(string name, IProduct[] products, Client[] clients)
        {
            Name = name;
            Products = products;
            Clients = clients;
            Status = BankWorkStatus.Working;
            Menu = new();
        }

        public void Run()
        {
            var actionSelector = new ActionSelector(Products, Clients);
            Console.WriteLine($"Здравствуйте, Вас приветсвует {Name}!");
            var menu = Menu.MainMenu;
            while (Status == BankWorkStatus.Working)
            {
                actionSelector.ShowMenu(menu);
                CheckInput(menu, out (int, string) selectedOption);
                if (IsClosed(selectedOption.Item2))
                {
                    Status = BankWorkStatus.Closed;
                    continue;
                }

                menu = Menu.SelectMenu(selectedOption);
                actionSelector.DoAction(selectedOption);
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
