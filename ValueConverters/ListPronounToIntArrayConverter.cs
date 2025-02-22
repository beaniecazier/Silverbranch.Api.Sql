using BeaniesUtilities.Models.Enum;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BeaniesUtilities.SQLDataOperations.ValueConverters;

public class ListPronounToIntArrayConverter : ValueConverter<List<ePronoun>, IEnumerable<int>>
{
    public ListPronounToIntArrayConverter() :
        base(list =>  list.Select(x => (int)x),
        arr => arr.Select(x => Enum.ToObject(typeof(ePronoun), x)).Cast<ePronoun>().ToList())
    {
    }
}
