using Gay.Silverbranch.API.Models.Enum;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gay.Silverbranch.API.SQL.ValueConverters;

public class ListPronounToIntArrayConverter : ValueConverter<List<ePronoun>, IEnumerable<int>>
{
    public ListPronounToIntArrayConverter() :
        base(list =>  list.Select(x => (int)x),
        arr => arr.Select(x => System.Enum.ToObject(typeof(ePronoun), x)).Cast<ePronoun>().ToList())
    {
    }
}
