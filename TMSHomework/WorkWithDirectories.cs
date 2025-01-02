using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class WorkWithDirectories
    {
        public static List<DirectoryInfo> GetAlbums(List<FileInfo> files)
        {
            return files
                .Where(f => Regex.IsMatch(f.Name, @"(mp3|wav)$"))
                .DistinctBy(f => f.DirectoryName)
                .Select(f => f.Directory)
                .ToList();
        }
    }
}
