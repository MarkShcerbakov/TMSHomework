namespace TMSHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TMS Lesson8-Task1-Animal-Dog");
            Console.WriteLine("Приложение осуществляет наследование класса Dog от абстрактного класса Aniumal.\n");

            Console.WriteLine("Введите имя собаки:");
            var dogName = Console.ReadLine();
            var dog = new Dog();
            dog.SetName(dogName);
            Console.WriteLine($"Вы назвали собаку именем {dog.GetName()}");
            Console.WriteLine("В настоящее время:");
            dog.Eat();
            Console.ReadKey();
        }
    }
}
