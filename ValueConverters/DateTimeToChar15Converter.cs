using System.Globalization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeaniesUtilities.SQLDataOperations.ValueConverters;

public class DateTimeToChar15Converter : ValueConverter<DateTime, string>
{
    public DateTimeToChar15Converter() : base(
        dateTime => dateTime.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture),
        stringValue => DateTime.ParseExact(stringValue, "yyyyMMdd_HHmmss", CultureInfo.InvariantCulture)
        )
    { }
}
