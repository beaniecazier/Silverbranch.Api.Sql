using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using Gay.Silverbranch.Api.Models.Enum.V1;

namespace Gay.Silverbranch.Api.Sql.ValueConverters;

public class ListEPronounToIntArrayConverter : ValueConverter<List<ePronoun>, IEnumerable<int>>
{
    public ListEPronounToIntArrayConverter() :
        base(list =>  list.Select(x => (int)x),
        arr => arr.Select(x => System.Enum.ToObject(typeof(ePronoun), x)).Cast<ePronoun>().ToList())
    {
    }
}
