using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using Gay.Silverbranch.API.Models.Enum;

namespace Gay.Silverbranch.API.SQL.ValueConverters;

public class ListSkillCategoryToIntArrayConverter : ValueConverter<List<eSkillCategory>, IEnumerable<int>>
{
    public ListSkillCategoryToIntArrayConverter() :
        base(list => list.Select(x => (int)x),
        arr => arr.Select(x => System.Enum.ToObject(typeof(eSkillCategory), x)).Cast<eSkillCategory>().ToList())
    {
    }
}
