namespace ClassLibrary1
{
    public class Person
    {
        public string Name { get; }
        public string Birthdate { get; }
        public Person(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }
    }
}
