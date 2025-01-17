namespace TMSHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TMS Lesson10-Task1-InputValidator");
            Console.WriteLine("Приложение осуществляет проверку введенных пользователем данных, выброс соответсвующих исключений и их обработку, а также тестирование.\n");

            Console.WriteLine("Введите имя пользователя:");
            var userName = Console.ReadLine();
            Console.WriteLine("Введите пароль:");
            var userPassword = Console.ReadLine();
            Console.WriteLine("Введите подтверждение пароля:");
            var userConfirmPassword = Console.ReadLine();

            var result = InputValidator.IsCorrectInput(userName, userPassword, userConfirmPassword);
        }
    }
}
