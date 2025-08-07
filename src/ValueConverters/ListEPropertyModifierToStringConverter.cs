using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using Gay.Silverbranch.Api.Models.Enum.V1;

namespace Gay.Silverbranch.Api.Sql.ValueConverters;

public class ListEPropertyModifierToStringConverter :  ValueConverter<List<ePropertyModifier>, string>
{
    public ListEPropertyModifierToStringConverter() :
        base(list => ListToString(list),
        str => StringToList(str))
    {
    }

    private static List<ePropertyModifier> StringToList(string str)
    {
        if (string.IsNullOrWhiteSpace(str)) return Enumerable.Empty<ePropertyModifier>().ToList();
        var items = str.Split(',');
        var results = items
            .Select(
                x =>
                {
                    if(string.IsNullOrWhiteSpace(x)) return ePropertyModifier.None;
                    ePropertyModifier Modifier = System.Enum.Parse<ePropertyModifier>(x, ignoreCase: true);
                    return Modifier;
                })
            .ToList();
        return results;
    }

    private static string ListToString(List<ePropertyModifier> values) =>
        values.Count == 0 ?
            ePropertyModifier.None.ToString() :
            string.Join(",", values.Select(c => c.ToString()));
}