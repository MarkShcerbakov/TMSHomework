namespace TMSHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TMS Lesson3-Task2-AdvancedCalculator");
            Console.WriteLine("Приложение рассчитывает результат математических выражений вида: (2*3^2)*3-5%2.");
            Console.WriteLine("Допустимые символы для использования: *, /, +, -, ^ (возведение в степень), % (остаток от деления по модулю)");
            Console.WriteLine("Использование пробелов не допускается.");
            Console.WriteLine("Введите выражение для расчета:");

            var expression = Console.ReadLine();
            var rpn = new AdvancedCalculator(expression);
            Console.WriteLine($"Результат: {rpn.Compute()}");
            Console.ReadKey();
        }
    }
}
