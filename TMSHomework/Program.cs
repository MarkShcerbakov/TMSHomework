namespace TMSHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Homework after lesson 1 in TMS school, task2.");

            if (File.Exists("words.txt"))
            {
                string[] words = File.ReadAllLines("words.txt").Select(w => w.Trim()).ToArray();
                Console.WriteLine("Введите кол-во строк в стихе: ");
                int rows;
                while (true)
                {
                    bool correctRows = int.TryParse(Console.ReadLine(), out rows);
                    if (correctRows && rows > 0) break;
                    else
                    {
                        Console.WriteLine("Введите корректное значение!");
                    }
                }

                List<string[]> poem = new();
                Random rnd = new();
                for (int row = 0; row < rows; row++)
                {
                    if (row % 2 == 0)
                    {
                        poem.Add(new string[rows].Select(_ => words[rnd.Next(words.Length)]).ToArray());
                    }
                    else
                    {
                        string[] endingWords = words.Where(w => w[^2..] == poem[^1][^1][^2..]).ToArray();
                        string word = endingWords[rnd.Next(endingWords.Length)];
                        poem.Add(new string[rows - 1].Select(_ => words[rnd.Next(words.Length)]).Append(word).ToArray());
                    }
                }

                Console.WriteLine("\nВаш стих:");
                foreach (string[] item in poem)
                {
                    Console.WriteLine(string.Join(" ", item));
                }
            }
            else
            {
                Console.WriteLine("Файл со словами не найден!");
            }

            Console.ReadKey();
        }
    }
}
