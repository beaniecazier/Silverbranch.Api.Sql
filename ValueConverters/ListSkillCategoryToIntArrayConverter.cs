using BeaniesUtilities.Models.Enum;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaniesUtilities.SQLDataOperations.ValueConverters;

public class ListSkillCategoryToIntArrayConverter : ValueConverter<List<eSkillCategory>, IEnumerable<int>>
{
    public ListSkillCategoryToIntArrayConverter() :
        base(list => list.Select(x => (int)x),
        arr => arr.Select(x => Enum.ToObject(typeof(eSkillCategory), x)).Cast<eSkillCategory>().ToList())
    {
    }
}
