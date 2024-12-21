namespace TMSHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TMS Lesson3-Task1-BasicCalculator");
            Console.WriteLine("Приложение выполняет простейшие математические действия над парой чисел.");
            Console.WriteLine("Допустимые выражения: +, -, *, /, ^ (возведение в степень), % (процент от числа).");

            double a, b;
            string op;
            Console.WriteLine("Введите первое число:");
            while (true)
            {
                var s = Console.ReadLine();
                double tmp = 0;
                bool isValidNumber = double.TryParse(s, out a);
                if (!isValidNumber)
                {
                    Console.WriteLine("Введите корректное число!");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Введите второе число:");
            while (true)
            {
                var s = Console.ReadLine();
                bool isValidNumber = double.TryParse(s, out b);
                if (!isValidNumber)
                {
                    Console.WriteLine("Введите корректное число!");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Введите операцию:");
            while (true)
            {
                op = Console.ReadLine();
                var operations = "+-*/^%";
                if (!operations.Contains(op))
                {
                    Console.WriteLine("Введите корректную операцию!");
                }
                else
                {
                    break;
                }
            }

            var calc = new BasicCalculator(a, b, op);
            var res = calc.Compute();
            Console.WriteLine($"Результат вычисления: {res}");
        }
    }
}
