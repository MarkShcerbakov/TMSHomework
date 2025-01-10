using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class ActionSelector
    {
        public delegate void MethodSelector();
        public IProduct[] Products { get; set; }
        public Client[] Clients { get; set; }
        public Dictionary<int, MethodSelector> Actions { get; set; }
        public int ClientChoice { get; set; }
        public int ProductChoice { get; set; }

        public ActionSelector(IProduct[] products, Client[] clients)
        {
            Products = products;
            Clients = clients;
            Actions = new()
            {
                [1] = ShowProducts,
                [2] = ShowProduct,
                [3] = ShowClients,
                [4] = ShowClient,
                [5] = RemoveProductFromClient,
                [6] = AddProductToClient
            };
        }

        public void DoAction((int, string) selectedOption)
        {
            if (Actions.TryGetValue(selectedOption.Item1, out MethodSelector methodSelector))
            {
                methodSelector();
            }
        }

        public void ShowClients()
        {
            Console.WriteLine($"В настоящее время в банке всего {Clients.Length} клиентов.");
            for (int i = 0; i < Clients.Length; i++)
            {
                Console.WriteLine($"{i + 1}.{Clients[i].FirstName} {Clients[i].LastName}");
            }
        }

        public void ShowClient()
        {
            Console.WriteLine("Введите номер клиента");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice <= 0 || choice > Clients.Length)
            {
                Console.WriteLine("Введите корректное значение!");
            }
            Console.WriteLine(Clients[choice - 1].GetClientInfo());
            ClientChoice = choice;
        }

        public void ShowProduct()
        {
            Console.WriteLine("Введите номер продукта");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice <= 0 || choice > Products.Length)
            {
                Console.WriteLine("Введите корректное значение!");
            }
            Console.WriteLine(Products[choice - 1].GetShortProductInfo());
            ProductChoice = choice;
        }

        public void ShowProducts()
        {
            Console.WriteLine($"В настоящее время банк предлагает следующие продукты");
            for (int i = 0; i < Products.Length; i++)
            {
                Console.WriteLine($"={i + 1}=" + Products[i].GetShortProductInfo());
            }
        }

        public void AddProductToClient()
        {
            ShowProducts();
            ShowProduct();
            Console.WriteLine("Введите необходимые данные о продукте");
            var productProperties = Products[ProductChoice - 1].GetType().GetProperties();
            var arguments = new List<decimal>();
            foreach (var property in productProperties)
            {
                int argument;
                Console.WriteLine(property.CustomAttributes.First().NamedArguments.First().TypedValue);
                while (!int.TryParse(Console.ReadLine(), out argument) || argument < 0)
                {
                    Console.WriteLine("Введите корректное значение!");
                }
                arguments.Add(argument);
            }

            var product = Activator.CreateInstance(Products[ProductChoice - 1].GetType(), arguments.Cast<object>().ToArray());
            Clients[ClientChoice - 1].Products.Add(product as IProduct);
            Console.WriteLine("Продукт добавлен");
        }

        public void RemoveProductFromClient()
        {
            Console.WriteLine("Введите номер продукта (0 - выход)");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > Clients[ClientChoice - 1].Products.Count)
            {
                Console.WriteLine("Введите корректное значение!");
            }
            if (choice == 0) return;
            Console.WriteLine($"Продукт {Clients[ClientChoice - 1].Products[choice - 1].GetProductInfo()} удален!");
            Clients[ClientChoice - 1].Products.RemoveAt(choice - 1);
            Console.WriteLine(Clients[ClientChoice - 1].GetClientInfo());
        }

        public void ShowMenu(Dictionary<int, (int, string)> menu)
        {
            Console.WriteLine("Сделайте выбор:");
            foreach (var menuItem in menu)
            {
                Console.WriteLine($"{menuItem.Key}.{menuItem.Value.Item2}");
            }
        }
    }
}
