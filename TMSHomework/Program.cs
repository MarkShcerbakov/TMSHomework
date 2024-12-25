using System.Data;

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
            Console.WriteLine(string.Concat(matrix.Select(row => string.Join(" ", row) + "\n")));
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

                switch (choice)
                {
                    case 1:
                        var choiceOne = MatrixOperations.NumberOfPositiveElements(matrix);
                        Console.WriteLine($"\nВ матрице всего {choiceOne.Length} положительных элементов: {string.Join(",", choiceOne)}");
                        Console.WriteLine("Выберити следующие действия над матрицей:");
                        break;
                    case 2:
                        var choiceTwo = MatrixOperations.NumberOfNegativeElements(matrix);
                        Console.WriteLine($"\nВ матрице всего {choiceTwo.Length} отрицательных элементов: {string.Join(",", choiceTwo)}");
                        Console.WriteLine("Выберити следующие действия над матрицей:");
                        break;
                    case 3:
                        var choiceThree = MatrixOperations.SortRowsOfMatrix(matrix);
                        Console.WriteLine($"\nОтсортированные по возрастанию строки матрицы:");
                        MatrixOperations.MatrixDisplay(choiceThree);
                        Console.WriteLine("Выберити следующие действия над матрицей:");
                        break;
                    case 4:
                        var choiceFour = MatrixOperations.SortRowsOfMatrixDecending(matrix);
                        Console.WriteLine($"\nОтсортированные по убыванию строки матрицы:");
                        MatrixOperations.MatrixDisplay(choiceFour);
                        Console.WriteLine("Выберити следующие действия над матрицей:");
                        break;
                    case 5:
                        var choiceFive = MatrixOperations.SortMatrix(matrix);
                        Console.WriteLine($"\nОтсортированная по возрастанию матрица:");
                        MatrixOperations.MatrixDisplay(choiceFive);
                        Console.WriteLine("Выберити следующие действия над матрицей:");
                        break;
                    case 6:
                        var choiceSix = MatrixOperations.SortMatrixDescending(matrix);
                        Console.WriteLine($"\nОтсортированная по убыванию матрица:");
                        MatrixOperations.MatrixDisplay(choiceSix);
                        Console.WriteLine("Выберити следующие действия над матрицей:");
                        break;
                    case 7:
                        var choiceSeven = MatrixOperations.InverseRowsOfMatrix(matrix);
                        Console.WriteLine($"\nИнверсия строк матрицы:");
                        MatrixOperations.MatrixDisplay(choiceSeven);
                        Console.WriteLine("Выберити следующие действия над матрицей:");
                        break;
                    case 8:
                        var choiceEight = MatrixOperations.InverseMatrix(matrix);
                        Console.WriteLine($"\nИнверсия строк матрицы:");
                        MatrixOperations.MatrixDisplay(choiceEight);
                        Console.WriteLine("Выберити следующие действия над матрицей:");
                        break;
                    case 9:
                        if (matrix.Length != matrix[0].Length)
                        {
                            Console.WriteLine("Невозможно рассчитать определитель матрицы!");
                            break;
                        }
                        var choiceNine = MatrixOperations.MatrixDeterminant(matrix);
                        Console.WriteLine($"\nОпределитель матрицы:");
                        Console.WriteLine(choiceNine);
                        Console.WriteLine("Выберити следующие действия над матрицей:");
                        break;
                    default:
                        Console.WriteLine("Введите корректное значение!");
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
