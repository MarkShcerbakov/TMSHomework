namespace TMSHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Описание приложенияя
            Console.WriteLine("TMS Lesson4-Task2-MatrixOperations");
            Console.WriteLine("Приложение позволяет осуществить следующие операции над матрицами:");
            Console.WriteLine("1. Найти кол-во положительных (отрицательных) элементов");
            Console.WriteLine("2. Сортировка элементов (построчно/во всей матрице)");
            Console.WriteLine("3. Инверсия элементов (построчно/во всей матрице)");
            Console.WriteLine("4. Бонус*** Нахождение определителя матрицы (только для квадратных матриц)");

            // Считываем кол-во строк и столбцов матрицы
            int rows, cols, maxRows = 10, maxCols = 10;
            int[][] matrix;
            Console.WriteLine($"\nВведите кол-во строк в матрице (не более {maxRows}):");
            while (!int.TryParse(Console.ReadLine(), out rows) || rows > maxRows)
            {
                Console.WriteLine("Введите корректное значение!");
            }

            Console.WriteLine($"\nВведите кол-во столбцов в матрице (не более {maxCols}):");
            while (!int.TryParse(Console.ReadLine(), out cols) || cols > maxCols)
            {
                Console.WriteLine("Введите корректное значение!");
            }

            // Заполняем матрицу значениями
            var strMatrix = new List<string>();
            Console.WriteLine($"\nВведите построчно через пробел элементы матрицы {rows} x {cols}:");
            while (true)
            {
                for (int row = 0; row < rows; row++)
                {
                    strMatrix.Add(Console.ReadLine());
                }

                matrix = MatrixBuilder.GetMatrix(strMatrix, cols);
                if (matrix is null)
                {
                    Console.WriteLine($"Введите корректную матрицу {rows}x{cols}:");
                    strMatrix.Clear();
                }
                else
                {
                    break;
                }
            }

            // Отоброжаем меню работы с матрицей
            Console.WriteLine("\nВы ввели следующую матрицу:");
            MatrixOperations.MatrixDisplay(matrix);
            MainMenu.ShowMenu();

            // Выбираем опции по работе с матрицей 
            while (true)
            {
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Сделайте корректый выбор!");
                }
                if (choice == 0)
                {
                    Console.WriteLine("Спасибо за работу в приложении!\nУдачного дня!");
                    break;
                }

                var operation = MatrixOperations.GetOperator(choice);
                var description = MainMenu.GetDescription(choice);
                if (operation is null || description is null)
                {
                    Console.WriteLine("Сделайте корректый выбор!");
                    continue;
                }
                else
                {
                    Console.WriteLine(description);
                    MatrixOperations.MatrixDisplay(operation(matrix));
                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }
    }
}
