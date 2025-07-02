using Gay.Silverbranch.API.Models.Enum;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gay.Silverbranch.API.SQL.ValueConverters;

public class ListPropConstraintToStringConverter :  ValueConverter<List<ePropertyConstraint>, string>
{
    public ListPropConstraintToStringConverter() :
        base(list => ListToString(list),
        str => StringToList(str))
    {
    }

    private static List<ePropertyConstraint> StringToList(string str)
    {
        if (string.IsNullOrWhiteSpace(str)) return Enumerable.Empty<ePropertyConstraint>().ToList();
        var items = str.Split(',');
        var results = items
            .Select(
                x =>
                {
                    if(string.IsNullOrWhiteSpace(x)) return ePropertyConstraint.None;
                    ePropertyConstraint constraint = System.Enum.Parse<ePropertyConstraint>(x, ignoreCase: true);
                    return constraint;
                })
            .ToList();
        return results;
    }

    private static string ListToString(List<ePropertyConstraint> values)
    {
        if (values.Count == 0) return ePropertyConstraint.None.ToString();
        return string.Join(",", values.Select(c => c.ToString()));
    }
}