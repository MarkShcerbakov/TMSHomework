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
            DirectoryInfo dir = new(dirPath);
            if (dir.Exists)
            {
                var files = dir.GetFiles().Where(file => file.Name.EndsWith("json", StringComparison.OrdinalIgnoreCase)
                    && file.Name.Contains(textInFileName, StringComparison.OrdinalIgnoreCase));
                if (files.Any())
                {
                    filePath = files.First().FullName;
                    return true;
                }
            }

            filePath = null;
            return false;
        }
    }
}
