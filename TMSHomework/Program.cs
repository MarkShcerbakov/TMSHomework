namespace TMSHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TMS Lesson4-Task2-MatrixOperations");
            Console.WriteLine("Приложение позволяет осуществить следующие операции над матрицами:");
            Console.WriteLine("1. Найти кол-во положительных (отрицательных) элементов");
            Console.WriteLine("2. Сортировка элементов (построчно/во всей матрице)");
            Console.WriteLine("3. Инверсия элементов (построчно/во всей матрице)");
            Console.WriteLine("4. Бонус*** Нахождение определителя матрицы (только для квадратных матриц)");

            var mainMenu = new Dictionary<int, Func<int[][], Array>>()
            {
                [1] = MatrixOperations.NumberOfPositiveElements,
                [2] = MatrixOperations.NumberOfNegativeElements,
                [3] = MatrixOperations.SortRowsOfMatrix,
                [4] = MatrixOperations.SortRowsOfMatrixDecending,
                [5] = MatrixOperations.SortMatrix,
                [6] = MatrixOperations.SortMatrixDescending,
                [7] = MatrixOperations.InverseRowsOfMatrix,
                [8] = MatrixOperations.InverseMatrix,
                [9] = MatrixOperations.MatrixDeterminant
            };

            var mainMenuComments = new Dictionary<int, string>()
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


            int rows, cols, maxRows = 10, maxCols = 10;
            int[][] matrix;
            Console.WriteLine("\nВведите кол-во строк в матрице (не более 10):");
            while (!int.TryParse(Console.ReadLine(), out rows) || rows > maxRows)
            {
                Console.WriteLine("Введите корректное значение!");
            }

            Console.WriteLine("\nВведите кол-во столбцов в матрице (не более 10):");
            while (!int.TryParse(Console.ReadLine(), out cols) || cols > maxCols)
            {
                Console.WriteLine("Введите корректное значение!");
            }

            var strMatrix = new List<string>();
            Console.WriteLine($"\nВведите построчно через пробел элементы матрицы {rows} x {cols}:");
            while (true)
            {
                for (int row = 0; row < rows; row++)
                {
                    strMatrix.Add(Console.ReadLine());
                }
                var tmpMatrix = strMatrix.Select(s => s.Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToArray();
                var correctCol = tmpMatrix.All(s => s.Length == cols);
                var correctValues = tmpMatrix.All(s => s.All(x => int.TryParse(x, out int _)));

                if (correctCol && correctValues)
                {
                    matrix = tmpMatrix.SelectMany(s => s.Select(int.Parse)).Chunk(cols).ToArray();
                    break;
                }
                else
                {
                    Console.WriteLine($"Введите корректную матрицу {rows}x{cols}:");
                    strMatrix.Clear();
                }
            }

            Console.WriteLine("\nВы ввели следующую матрицу:");
            MatrixOperations.MatrixDisplay(matrix);
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

                if (!mainMenu.TryGetValue(choice, out Func<int[][], Array> operationDelegate))
                {
                    Console.WriteLine("Сделайте корректый выбор!");
                    continue;
                }
                else
                {
                    Console.WriteLine(mainMenuComments[choice]);
                    MatrixOperations.MatrixDisplay(operationDelegate(matrix));
                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }
    }
}
