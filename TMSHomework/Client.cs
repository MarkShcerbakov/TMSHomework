using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class Client
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public decimal Money;
        public List<IProduct> Products;

        public Client(int id, string firstName, string lastName, decimal money, List<IProduct> products)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Money = money;
            Products = products;
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
