using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TMSHomework
{
    public class XmlSuperHeroSquadParser
    {
        public static void Serialize(string dirPath, SuperHeroSquad superHeroSquad)
        {
            var squadName = SquadNameToCamalCase(superHeroSquad.SquadName);
            using (FileStream fs = new($"{dirPath}/{squadName}", FileMode.Create))
            {
                var xmlSerializer = new XmlSerializer(typeof(SuperHeroSquad));
                xmlSerializer.Serialize(fs, superHeroSquad);
            }
        }

        private static string SquadNameToCamalCase(string squadName)
        {
            var name = squadName.ToLower().Split().Select((s, i) => i == 0 ? s : $"{char.ToUpper(s[0])}{s[1..]}");
            return string.Concat(name) + ".xml";
        }
    }
}
