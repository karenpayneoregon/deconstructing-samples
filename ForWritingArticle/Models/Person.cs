namespace ForWritingArticle.Models
{
    public record Person()
    {
        public int Id { get; init; }
        public string Firstname { get; init; }
        public string Lastname { get; init; }

        public void Deconstruct(out string firstName, out string lastName) 
            => (firstName, lastName) = (Firstname, Lastname);
    }
}