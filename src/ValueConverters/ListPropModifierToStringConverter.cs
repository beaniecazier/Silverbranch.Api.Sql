using Gay.Silverbranch.API.Models.Enum;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gay.Silverbranch.API.SQL.ValueConverters;

public class ListPropModifierToStringConverter :  ValueConverter<List<ePropertyModifier>, string>
{
    public ListPropModifierToStringConverter() :
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

    private static string ListToString(List<ePropertyModifier> values)
    {
        if (values.Count == 0) return ePropertyModifier.None.ToString();
        return string.Join(",", values.Select(c => c.ToString()));
    }
}