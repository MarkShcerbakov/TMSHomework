namespace TMSHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TMS Lesson13-Task1-JSONParsing");
            Console.WriteLine("Приложение парсит JSON-документ и сохраняет его в виде xml");

            Console.WriteLine("Введите путь к папке с файлом Super hero squad.json:");
            var dirPath = Console.ReadLine();

            if (JsonSuperHeroSquadPathChecker.TryGetFilePath(dirPath, "Super hero squad", out string filePath))
            {
                JsonSuperHeroSquadParser.Deserialize(filePath, out SuperHeroSquad superHeroSquad);
                XmlSuperHeroSquadParser.Serialize(dirPath, superHeroSquad);
            }
            else
            {
                Console.WriteLine("В данной директории отсутсвуют файл Super hero squad.json");
            }

            Console.Read();
        }
    }
}
