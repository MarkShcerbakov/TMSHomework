namespace TMSHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TMS Lesson3-Task3-CheatCalculator");
            Console.WriteLine("Приложение рассчитывает результат математических выражений вида: (2*3+1)*3-5/2.");
            Console.WriteLine("Допустимые символы для использования: *, /, +, -, (, ), .");
            Console.WriteLine("Введите выражение для расчета:");

            var expression = Console.ReadLine();
            var calc = new CheatCalculator(expression);
            Console.WriteLine($"Результат: {calc.Compute()}");
            Console.ReadKey();
        }
    }
}
