using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TMSHomework
{
    public class SuperHeroSquad
    {
        [JsonPropertyName("squadName")]
        [XmlAttribute("squadName")]
        public string SquadName { get; set; }

        [JsonPropertyName("homeTown")]
        [XmlAttribute("homeTown")]
        public string HomeTown { get; set; }

        [JsonPropertyName("formed")]
        [XmlAttribute("formed")]
        public int Formed { get; set; }

        [JsonPropertyName("secretBase")]
        [XmlAttribute("secretBase")]
        public string SecretBase { get; set; }

        [JsonPropertyName("active")]
        [XmlAttribute("active")]
        public bool Active { get; set; }

        [JsonPropertyName("members")]
        [XmlArray("members")]
        public Member[] Members { get; set; }
    }
}
