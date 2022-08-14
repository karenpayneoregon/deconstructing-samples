namespace ForWritingArticle.Models
{
    public record Person()
    {
        public int Id { get; init; }
        public string Firstname { get; init; }
        public string Lastname { get; init; }
        public string FullName => $"{Firstname} {Lastname}";

        public override string ToString() => $"{Id} {FullName}";

        public void Deconstruct(out int id, out string fullName)
            => (id, fullName) = (Id, FullName);

    }
}