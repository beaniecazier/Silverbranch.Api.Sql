using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using Gay.Silverbranch.API.Models.Enum.V1;

namespace Gay.Silverbranch.Api.Sql.ValueConverters;

public class ListSkillCategoryToIntArrayConverter : ValueConverter<List<eSkillCategory>, IEnumerable<int>>
{
    public ListSkillCategoryToIntArrayConverter() :
        base(list => list.Select(x => (int)x),
        arr => arr.Select(x => System.Enum.ToObject(typeof(eSkillCategory), x)).Cast<eSkillCategory>().ToList())
    {
    }
}
