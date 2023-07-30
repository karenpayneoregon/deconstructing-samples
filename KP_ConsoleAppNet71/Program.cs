using System.Collections.ObjectModel;
namespace KP_ConsoleAppNet71;

internal partial class Program
{
    static void Main(string[] args)
    {
        // test to see if string is a DateTimeOffset
        if (DateTimeOffset.TryParse("2023-02-11 13:40:52.000 +0700", out var dt))
        {
            var date = dt.Date;
        }

        ShowPossibleTimeZones(dt);

        // provides access to each part
        var (day, month, year, hour, minutes, seconds, milliseconds, offset) = dt;

        Console.WriteLine(offset);
        Console.WriteLine(dt.DateTime);

        Console.ReadLine();
    }

    private static void ShowPossibleTimeZones(DateTimeOffset offsetTime)
    {
        TimeSpan offset = offsetTime.Offset;
        Console.WriteLine("{0} could belong to the following time zones:", offsetTime.ToString());
        ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
        foreach (TimeZoneInfo timeZone in timeZones)
        {
            if (timeZone.GetUtcOffset(offsetTime.DateTime).Equals(offset))
            {
                Console.WriteLine("   {0}", timeZone.DisplayName);
            }
        }


    }
}

public static class Extensions
{
    public static void Deconstruct(this DateTimeOffset date, out int day, out int month, out int year, out int hour, out int minutes, out int seconds, out int milliseconds, out TimeSpan offset)
        => (day, month, year, hour, minutes, seconds, milliseconds, offset) = 
            (date.Day, date.Month, date.Year, date.Hour, date.Minute, date.Second, date.Millisecond, date.Offset);

    public static void Deconstruct(this DateTimeOffset date, out int day, out int month, out int year)
        => (day, month, year) = (date.Day, date.Month, date.Year);
}