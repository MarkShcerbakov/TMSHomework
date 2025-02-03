using TMSHomework;

namespace JsonXmlParserTests
{
    public class JsonXmlParserTests
    {
        [Fact]
        public void Deserialize_ShouldSuccess()
        {
            JsonSuperHeroSquadParser.Deserialize("Test super hero squad.json", out SuperHeroSquad superHeroSquad);

            Assert.Equal("Super hero squad", superHeroSquad.SquadName);
            Assert.Equal("Metro City", superHeroSquad.HomeTown);
            Assert.Equal(2016, superHeroSquad.Formed);
            Assert.Equal("Super tower", superHeroSquad.SecretBase);
            Assert.True(superHeroSquad.Active);

            Assert.Equal("Molecule Man", superHeroSquad.Members[0].Name);
            Assert.Equal(29, superHeroSquad.Members[0].Age);
            Assert.Equal("Dan Jukes", superHeroSquad.Members[0].SecretIdentity);
            Assert.Equal("Radiation resistance", superHeroSquad.Members[0].Powers[0]);
            Assert.Equal("Turning tiny", superHeroSquad.Members[0].Powers[1]);
            Assert.Equal("Radiation blast", superHeroSquad.Members[0].Powers[2]);

            Assert.Equal("Madame Uppercut", superHeroSquad.Members[1].Name);
            Assert.Equal(39, superHeroSquad.Members[1].Age);
            Assert.Equal("Jane Wilson", superHeroSquad.Members[1].SecretIdentity);
            Assert.Equal("Million tonne punch", superHeroSquad.Members[1].Powers[0]);
            Assert.Equal("Damage resistance", superHeroSquad.Members[1].Powers[1]);
            Assert.Equal("Superhuman reflexes", superHeroSquad.Members[1].Powers[2]);

            Assert.Equal("Eternal Flame", superHeroSquad.Members[2].Name);
            Assert.Equal(1000000, superHeroSquad.Members[2].Age);
            Assert.Equal("Unknown", superHeroSquad.Members[2].SecretIdentity);
            Assert.Equal("Immortality", superHeroSquad.Members[2].Powers[0]);
            Assert.Equal("Heat Immunity", superHeroSquad.Members[2].Powers[1]);
            Assert.Equal("Inferno", superHeroSquad.Members[2].Powers[2]);
            Assert.Equal("Teleportation", superHeroSquad.Members[2].Powers[3]);
            Assert.Equal("Interdimensional travel", superHeroSquad.Members[2].Powers[4]);
        }

        [Fact]
        public void Serialize_ShouldSuccess()
        {
            JsonSuperHeroSquadParser.Deserialize("Test super hero squad.json", out SuperHeroSquad superHeroSquad);
            XmlSuperHeroSquadParser.Serialize(Directory.GetCurrentDirectory(), superHeroSquad);

            var xmlFile = File.ReadAllText("superHeroSquad.xml");
            var testFile = File.ReadAllText("testSuperHeroSquad.xml");
            Assert.Equal(xmlFile, testFile);
        }
    }
}