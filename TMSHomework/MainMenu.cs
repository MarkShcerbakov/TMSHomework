using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class MainMenu
    {
        private static Dictionary<int, string> _description = new()
        {
            [1] = "\nПоложительные элементы в матрице:",
            [2] = "\nОтрицательные элементы в матрице:",
            [3] = "\nОтсортированные по возрастанию строки матрицы:",
            [4] = "\nОтсортированные по убыванию строки матрицы:",
            [5] = "\nОтсортированная по возрастанию матрица:",
            [6] = "\nОтсортированная по убыванию матрица:",
            [7] = "\nИнверсия строк матрицы:",
            [8] = "\nИнверсия матрицы:",
            [9] = "\nОпределитель матрицы:",
        };

        public static void ShowMenu()
        {
            Console.WriteLine("Выберити следующие действия над матрицей:");
            Console.WriteLine("0. Закончить работу с приложением");
            Console.WriteLine("1. Найти кол-во положительных элементов");
            Console.WriteLine("2. Найти кол-во отрицательных элементов");
            Console.WriteLine("3. Сортировка элементов (построчно по возрастанию)");
            Console.WriteLine("4. Сортировка элементов (построчно по убыванию)");
            Console.WriteLine("5. Сортировка элементов (вся матрица по возрастанию)");
            Console.WriteLine("6. Сортировка элементов (вся матрица по убыванию)");
            Console.WriteLine("7. Инверсия элементов (построчно)");
            Console.WriteLine("8. Инверсия элементов (по всей матрице)");
            Console.WriteLine("9. Бонус*** Нахождение определителя матрицы (только для квадратных матриц)");
        }

        public static string GetDescription(int choice) => _description.TryGetValue(choice, out string description) ? description : null;
    }
}
