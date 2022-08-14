using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForWritingArticle.LanguageExtensions
{
    public static class Extensions
    {
        public static void Deconstruct(this DateTimeOffset date, out int day, out int month, out int year) 
            => (day, month, year) = (date.Day, date.Month, date.Year);

        public static (int day, int month, int year) Chunk(this DateTimeOffset sender) 
            => (sender.Day, sender.Month, sender.Year);
    }
}
