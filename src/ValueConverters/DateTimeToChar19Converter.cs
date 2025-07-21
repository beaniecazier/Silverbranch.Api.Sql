using System.Globalization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gay.Silverbranch.Api.Sql.ValueConverters;

public class DateTimeToChar19Converter : ValueConverter<DateTime, string>
{
    public DateTimeToChar19Converter() : base(
        dateTime => dateTime.ToString("yyyyMMdd_HHmmss.fff", CultureInfo.InvariantCulture),
        stringValue => DateTime.ParseExact(stringValue, "yyyyMMdd_HHmmss.fff", CultureInfo.InvariantCulture)
        )
    { }
}