using System.Globalization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gay.Silverbranch.API.SQL.ValueConverters;

public class DateTimeToChar22Converter : ValueConverter<DateTime, string>
{
    public DateTimeToChar22Converter() : base(
        dateTime => DateTimeToCharArray22AsString(dateTime),
        stringValue => CharArray22AsStringToDateTime(stringValue)
        )
    {
    }

    private static string DateTimeToCharArray22AsString(DateTime dateTime)
    {
        string date = dateTime.ToString("yyyyMMdd", CultureInfo.InvariantCulture);
        string time = dateTime.ToString("HHmmss", CultureInfo.InstalledUICulture);
        string fraction = dateTime.ToString("ffffff", CultureInfo.InvariantCulture);
        return date+"_"+time+"."+fraction;
    }

    static DateTime CharArray22AsStringToDateTime(string stringValue)
    {
        DateTime date = DateTime.ParseExact(stringValue.Substring(0,8), "yyyyMMdd", CultureInfo.InvariantCulture);
        TimeOnly time = TimeOnly.ParseExact(stringValue.Substring(9,6), "HHmmss", CultureInfo.InvariantCulture);
        int fraction = int.Parse(stringValue.Substring(16));
        //DateTime fraction = DateTime.ParseExact(stringValue.Substring(16), "ffffff", CultureInfo.InvariantCulture);
        return date.Add(time.ToTimeSpan()).AddMicroseconds(fraction);
    }
}
