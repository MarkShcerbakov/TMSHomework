using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class FileService
    {
        public static bool TryReadFile(string path, out string inputText)
        {
            var isFileExists = File.Exists(path);
            if (!isFileExists)
            {
                inputText = "";
                Console.WriteLine("\"Файл с текстом не найден!\"");
            }
            else
            {
                inputText = File.ReadAllText(path);
                PrintInputFile(inputText);
            }

            return isFileExists;
        }

        public static void PrintInputFile(string inputText)
        {
            Console.WriteLine(inputText + "\n");
        }
    }
}
