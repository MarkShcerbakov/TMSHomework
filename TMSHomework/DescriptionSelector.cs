using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class DescriptionSelector
    {
        public static Dictionary<int, string> Discriptions = new()
        {
            [1] = "\nСлова, содержащие максимальное кол-во цифр:",
            [2] = "\nСамое длинное слово и кол-во раз, встречаемых в тексте:",
            [3] = "\nТекст с замененными на строковые значения цифрами:",
            [4] = "\nВопросительные и восклицательные предложения:",
            [5] = "\nПредложения, не содержащие запятых:",
            [6] = "\nСлова, начинающиеся и заканчивающиеся на одну и ту же букву:"
        };

        public static void ShowMenu()
        {
            Console.WriteLine("Выберите дейстие:");
            Console.WriteLine("0. Выход из приложения");
            Console.WriteLine("1. Вывести слова, содержащие максимальное кол-во цифр");
            Console.WriteLine("2. Вывести самое длинное слово и кол-во раз, встречаемых в тексте");
            Console.WriteLine("3. Вывести текст с замененными на строковые значения цифрами");
            Console.WriteLine("4. Вывести вопросительные и восклицательные предложения");
            Console.WriteLine("5. Вывести предложения, не содержащие запятых");
            Console.WriteLine("6. Вывести слова, начинающиеся и заканчивающиеся на одну и ту же букву");
        }
    }
}
