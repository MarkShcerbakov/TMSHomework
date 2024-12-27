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
                var textParser = new TextParser(inputText);
            }
            else
            {
                Console.WriteLine("Файл с текстом не найден!");
            }
            foreach (var item in inputText)
            {
                Console.Write(item);
            }


            Console.ReadKey();

        }
    }
}
