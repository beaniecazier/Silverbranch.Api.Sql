using Gay.Silverbranch.Api.Models.Enum.V1;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gay.Silverbranch.Api.Sql.ValueConverters;

public class ListEPronounToStringConverter : ValueConverter<List<ePronoun>, string>
{
    public ListEPronounToStringConverter() :
        base(list => ListToString(list),
            str => StringToList(str)) { }

    private static List<ePronoun> StringToList(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return Enumerable.Empty<ePronoun>().ToList();
        var items = value.Split(',');
        var results = items
            .Select(
                x =>
                {
                    if(string.IsNullOrWhiteSpace(x)) return ePronoun.None;
                    return Enum.Parse<ePronoun>(x, ignoreCase: true);
                })
            .ToList();
        return results;
    }

    private static string ListToString(List<ePronoun> values)=>
        values.Count == 0 ?
            ePronoun.None.ToString() :
            string.Join(",", values.Select(x => x.ToString()));
}
