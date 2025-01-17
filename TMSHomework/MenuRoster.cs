using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class MenuRoster
    {
        public Dictionary<int, (int, string)> MainMenu { get; set; } = new()
        {
            [0] = (0, "Выйти из банка"),
            [1] = (1, "Информация о продуктах"),
            [2] = (3, "Информация о клиентах"),
        };

        public Dictionary<int, (int, string)> ClientsMenu { get; set; } = new()
        {
            [0] = (0, "Вернуться к услугам банка"),
            [1] = (4, "Выбрать клиента"),
            [2] = (7, "Добавить клиента"),
            //[3] = (4, "Удалить клиента")
        };

        public Dictionary<int, (int, string)> ProductsMenu { get; set; } = new()
        {
            [0] = (0, "Вернуться к услугам банка"),
            [1] = (2, "Выбрать продукт"),
            //[2] = (2, "Добавить продукт"),
            //[3] = (2, "Удалить продукт")
        };

        public Dictionary<int, (int, string)> ClientMenu { get; set; } = new()
        {
            [0] = (3, "Вернуться к клиентам"),
            [1] = (5, "Удалить услугу"),
            [2] = (6, "Добавить услугу")
        };

        public Dictionary<int, (int, string)> ProductMenu { get; set; } = new()
        {
            [0] = (1, "Вернуться к продуктам"),
            //[1] = (2, "Изменить услугу")
        };
    }
}
