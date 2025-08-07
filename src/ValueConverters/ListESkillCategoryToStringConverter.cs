using Gay.Silverbranch.Api.Models.Enum.V1;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gay.Silverbranch.Api.Sql.ValueConverters;

public class ListESkillCategoryToStringConverter : ValueConverter<List<eSkillCategory>, string>
{
    public ListESkillCategoryToStringConverter() :
        base(list => ListToString(list),
            str => StringToList(str)) { }

    private static List<eSkillCategory> StringToList(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return Enumerable.Empty<eSkillCategory>().ToList();
        var items = value.Split(',');
        var results = items
            .Select(
                x =>
                {
                    if(string.IsNullOrWhiteSpace(x)) return eSkillCategory.None;
                    return Enum.Parse<eSkillCategory>(x, ignoreCase: true);
                })
            .ToList();
        return results;
    }

    private static string ListToString(List<eSkillCategory> values) =>
        values.Count == 0 ?
            eSkillCategory.None.ToString() :
            string.Join(",", values.Select(x => x.ToString()));
}
