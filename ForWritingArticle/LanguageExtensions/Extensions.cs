namespace ForWritingArticle.LanguageExtensions
{
    public static class Extensions
    {
        public static void Deconstruct(this DateTimeOffset date, out int day, out int month, out int year) 
            => (day, month, year) = (date.Day, date.Month, date.Year);

        public static void Deconstruct(this DateTimeOffset date, out int day, out int month, out int year, out TimeSpan offset)
            => (day, month, year, offset) = (date.Day, date.Month, date.Year, date.Offset);
        public static (int day, int month, int year) Chunk(this DateTimeOffset sender) 
            => (sender.Day, sender.Month, sender.Year);

        public static void Deconstruct(this Version version, out int major, out int minor, out int build, out int revision)
            => (major, minor, build, revision) = (version.Major, version.Minor, version.Build, version.Revision);
    }
}
