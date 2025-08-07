using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gay.Silverbranch.Api.Sql.ValueConverters;

public class ListStringToStringConverter :  ValueConverter<List<string>, string>
{
    public ListStringToStringConverter() :
        base(list => ListToString(list),
            str => StringToList(str)) { }

    private static List<string> StringToList(string str) => 
        string.IsNullOrWhiteSpace(str) ?
            Enumerable.Empty<string>().ToList() :
            str.Split(",").ToList();

    private static string ListToString(List<string> values) =>
        values.Count == 0 ?
            string.Empty :
            string.Join(",", values.Select(c => c.ToString()));
}