namespace TMSHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TMS Lesson5-Task1-WorkWithText");
            Console.WriteLine("Приложение позволяет выводить информацию о введенном фрагменте текста.");
            Console.WriteLine("В данном случае будет приведен отрывок из спортивной статьи.\n");

            var filePath = "test.txt";
            if (!FileService.TryReadFile(filePath, out string inputText))
            {
                return;
            }
            var textParser = new TextParser(inputText);
            if (textParser.IsCorrectInputText)
            {
                DescriptionSelector.ShowMenu();
                while (UserChoice.GetChoice(Console.ReadLine(), out int choice))
                {
                    textParser.GetParsedText(choice);
                }
            }

            Console.ReadKey();
        }
    }
}
