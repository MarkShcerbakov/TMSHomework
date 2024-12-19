namespace TMSHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Homework after lesson 1 in TMS school, task3");

            Console.WriteLine("Вам с утра в снегопад необходимо вовремя добраться до работы.\nКакой путь вы выберете?");
            Console.WriteLine("1. Пойти пешком.");
            Console.WriteLine("2. Поехать на общественном транспорте.");
            Console.WriteLine("3. Поехать на такси.");

            int firstChoice = int.Parse(Console.ReadLine());

            if (firstChoice == 1)
            {
                Console.WriteLine("Вас занесло снегом и вы опоздали на работу. Игра закончена.");
            }
            else if (firstChoice == 2)
            {
                Console.WriteLine("На каком транспорте вы поедете?");
                Console.WriteLine("1. Автобус.");
                Console.WriteLine("2. Троллейбус.");
                Console.WriteLine("3. Трамвай.");

                int secondChoice = int.Parse(Console.ReadLine());

                if (secondChoice == 1)
                {
                    Console.WriteLine("В невыносимой давке и жаре от печки вы сумели добраться до работы во время, но утро оказалось испорченным. \nПоздравляю, вы справились!");
                }
                else if (secondChoice == 2)
                {
                    Console.WriteLine("К сожалению из-за налипания снега произошел обрыв проводов, и вы не смогли вовремя добраться. Игра закончена.");
                }
                else if (secondChoice == 3)
                {
                    Console.WriteLine("На середине пути рельсы сильно занесло снегом, и трамвай не смог вовремя доехать до вашей работы. Игра закончена.");
                }
            }
            else if (firstChoice == 3)
            {
                Console.WriteLine("Какой тариф вы выберете");
                Console.WriteLine("1. Эконом.");
                Console.WriteLine("2. Премиум.");

                int secondChoice = int.Parse(Console.ReadLine());

                if (secondChoice == 1)
                {
                    Console.WriteLine("К вам приехала неисправная машина. Игра закончена.");
                }
                else if (secondChoice == 2)
                {
                    Console.WriteLine("Вы добрались на кроссовере вовремя. Поздравляю, вы справились!");
                }
            }

            Console.ReadKey();
        }
    }
}
