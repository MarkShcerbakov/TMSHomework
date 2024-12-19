namespace TMSHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Homework after lesson 1 in TMS school, task4.");

            Console.WriteLine("Добро пожаловать в магазин! Сколько у Вас на счету монет?");
            int cash;
            while (true)
            {
                bool correctCash = int.TryParse(Console.ReadLine(), out cash);
                if (correctCash && cash > 0) break;
                else
                {
                    Console.WriteLine("Введите корректное значение кол-ва монет!");
                }
            }

            Random priceGen = new();
            (string Product, int Price)[] products =
            {
                ("Яблоко", priceGen.Next(30, 301)),
                ("Груша", priceGen.Next(30, 301)),
                ("Молоко", priceGen.Next(30, 301)),
                ("Хлеб", priceGen.Next(30, 301))
            };

            List<(string Product, int Price)> purchases = new();
            while (true)
            {
                Console.WriteLine($"\nУ вас в наличии - {cash} монет!\n");
                Console.WriteLine("Товары в наличии:");
                for (int product = 0; product < products.Length; product++)
                {
                    Console.WriteLine($"{product + 1}.{products[product].Product} - {products[product].Price} монет");
                }

                Console.WriteLine("\nВведите номер товара для покупки или \"0\" для выхода:");
                bool correctChoice = int.TryParse(Console.ReadLine(), out int choice);

                if (!correctChoice)
                {
                    Console.WriteLine("Введите корректное значение товара!");
                    continue;
                }
                if (choice == 0) break;
                if (choice < 0 || choice > products.Length)
                {
                    Console.WriteLine("Извините, такого товара сегодня нет в наличии.");
                    continue;
                }
                if (products[choice - 1].Price > cash)
                {
                    Console.WriteLine($"У вас недостаточно монет для приобретения {products[choice - 1].Product}. Выберите другой товар.");
                }
                else
                {
                    cash -= products[choice - 1].Price;
                    purchases.Add(products[choice - 1]);
                    Console.WriteLine($"\nВы купили:");
                    for (int purchase = 0; purchase < purchases.Count; purchase++)
                    {
                        Console.WriteLine($"{purchase + 1}. {purchases[purchase].Product} за {purchases[purchase].Price} монет");
                    }
                    Console.WriteLine($"На сумму: {purchases.Sum(x => x.Price)} монет");
                }
            }

            if (purchases.Count == 0)
            {
                Console.WriteLine("К сожалению вы ничего не купили.");
            }
            else
            {
                var allPurchases = purchases.GroupBy(t => t).ToArray();
                Console.WriteLine("\nВами были куплены следующие товары:");
                for (int purchase = 0; purchase < allPurchases.Length; purchase++)
                {
                    Console.WriteLine($"{purchase + 1}. {allPurchases[purchase].Key.Product} x {allPurchases[purchase].Count()} за {allPurchases[purchase].Key.Price * allPurchases[purchase].Count()} монет");
                }
                Console.WriteLine($"На сумму: {purchases.Sum(x => x.Price)} монет");
            }

            Console.ReadKey();
        }
    }
}
