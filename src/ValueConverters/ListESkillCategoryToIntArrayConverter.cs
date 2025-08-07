using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using Gay.Silverbranch.Api.Models.Enum.V1;

namespace Gay.Silverbranch.Api.Sql.ValueConverters;

public class ListESkillCategoryToIntArrayConverter : ValueConverter<List<eSkillCategory>, IEnumerable<int>>
{
    public ListESkillCategoryToIntArrayConverter() :
        base(list => ListToIntArr(list),
        arr => IntArrToList(arr)) { }

    private static IEnumerable<int> ListToIntArr(List<eSkillCategory> list)
    {
        return list.Select(x => (int)x);
    }

    private static List<eSkillCategory> IntArrToList(IEnumerable<int> arr) =>
        arr.Select(x => Enum.ToObject(typeof(eSkillCategory), x))
            .Cast<eSkillCategory>()
            .ToList();
}
