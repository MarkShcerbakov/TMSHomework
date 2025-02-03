using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    public class JsonSuperHeroSquadPathChecker
    {
        public static bool TryGetFilePath(string dirPath, string textInFileName, out string filePath)
        {
            if (string.IsNullOrWhiteSpace(dirPath))
            {
                filePath = null;
                return false;
            }

            if (Directory.Exists(dirPath))
            {
                var files = Directory.GetFiles(dirPath, "*.json", SearchOption.TopDirectoryOnly)
                    .Where(fileName => fileName.Contains(textInFileName, StringComparison.OrdinalIgnoreCase));
                if (files.Any())
                {
                    filePath = files.First();
                    return true;
                }
            }

            filePath = null;
            return false;
        }
    }
}
