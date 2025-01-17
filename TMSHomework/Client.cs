using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class Client
    {
        private int _id;
        private decimal _money;

        [Description("ИНН")]
        public int Id
        {
            get => _id;
            set => _id = value <= 0 || value > int.MaxValue ? throw new ArgumentException() : value;
        }

        [Description("Имя")]
        public string FirstName { get; set; }

        [Description("Фамилия")]
        public string LastName { get; set; }

        [Description("Количество денежных средств")]
        public decimal Money
        {
            get => _money;
            set => _money = value < 0 ? throw new ArgumentException() : value;
        }

        public List<IProduct> Products { get; set; }

        public Client(int id, string firstName, string lastName, decimal money, List<IProduct> products)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Money = money;
            Products = products;
        }

        public Client()
        {
            
        }

        public string GetClientInfo()
        {
            return $"\nФИО: {FirstName} {LastName}" +
                $"\nИНН: {Id}" +
                $"\nСредства на счете: {Money,0:N2}" +
                $"\nСписок продуктов:\n{string.Concat(Products.Select((product, i) => $"={i + 1}=" + product.GetProductInfo() + "\n"))}";
        }
    }
}
