namespace TMSHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TMS Lesson3-Task4-ExpressionCalculator");
            Console.WriteLine("Приложение рассчитывает результат математических выражений вида: (2*3^2)*3-5%2.");
            Console.WriteLine("Допустимые символы для использования: *, /, +, -, (, ), ^ (возведение в степень), % (остаток от деления по модулю)");
            Console.WriteLine("Введите выражение для расчета:");

            var expression = Console.ReadLine();
            Console.WriteLine($"Результат: {ExpressionCalculator.Compute(expression)}");
            Console.ReadKey();
        }
    }
}
