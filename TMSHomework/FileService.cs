using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class FileService
    {
        public static bool CheckInputFile(string path)
        {
            var check = File.Exists(path);
            if (!check)
            {
                Console.WriteLine("\"Файл с текстом не найден!\"");
            }
            return check;
        }

        public static string ReadInputFile(string path)
        {
            var inputText = File.ReadAllText("test.txt");
            Console.WriteLine(inputText + "\n");
            return inputText;
        }
    }
}
