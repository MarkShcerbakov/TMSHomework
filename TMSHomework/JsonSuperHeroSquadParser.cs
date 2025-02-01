using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TMSHomework
{
    public class JsonSuperHeroSquadParser
    {
        public static void Deserialize(string filePath, out SuperHeroSquad superHeroSquad)
        {
            using (FileStream fs = new(filePath, FileMode.Open))
            {
                superHeroSquad = JsonSerializer.Deserialize<SuperHeroSquad>(fs);
            }
        }
    }
}
