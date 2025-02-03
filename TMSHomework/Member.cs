using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TMSHomework
{
    public class Member
    {
        [JsonPropertyName("name")]
        [XmlAttribute("name")]
        public string Name { get; set; }

        [JsonPropertyName("age")]
        [XmlAttribute("age")]
        public int Age { get; set; }

        [JsonPropertyName("secretIdentity")]
        [XmlAttribute("secretIdentity")]
        public string SecretIdentity { get; set; }

        [JsonPropertyName("powers")]
        [XmlArray("powers")]
        public string[] Powers { get; set; }
    }
}
