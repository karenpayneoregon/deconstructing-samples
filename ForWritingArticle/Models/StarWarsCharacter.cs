namespace ForWritingArticle.Models
{
    public abstract class StarWarsCharacter
    {
        public string Name { get; }

        protected StarWarsCharacter(string name)
        {
            Name = name;
        }
    }
    public class Hero : StarWarsCharacter
    {
        public Hero(string name) : base($"The Good{name}") { }
        public string Healing() => "Performs healing";
    }

    public class Villain : StarWarsCharacter
    {
        public Villain(string name) : base($"The Evil {name}") { }

        public string Lightning() => "Performs Force lightning";
    }
}
