namespace TMSHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TMS Lesson5-Task1-WorkWithText");
            Console.WriteLine("Приложение позволяет выводить информацию о введенном фрагменте текста.");
            Console.WriteLine("В данном случае будет приведен отрывок из спортивной статьи.\n");

            var inputText = "";
            if (File.Exists("test.txt"))
            {
                inputText = File.ReadAllText("test.txt");
                Console.WriteLine(inputText + "\n");
                var textParser = new TextParser(inputText);
                DescriptionSelector.ShowMenu();

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

                    if (textParser.TextParserMethods.TryGetValue(choice, out Func<string[]> textParserMethods) &&
                        DescriptionSelector.Discriptions.TryGetValue(choice, out string description))
                    {
                        Console.WriteLine(description);
                        foreach (var item in textParserMethods())
                        {
                            Console.WriteLine(item);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Сделайте корректый выбор!");
                        continue;
                    }
                }

            }
            else
            {
                Console.WriteLine("Файл с текстом не найден!");
            }

            Console.ReadKey();
        }
    }
}
