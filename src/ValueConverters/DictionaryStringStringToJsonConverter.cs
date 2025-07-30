using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.IdentityModel.Tokens;

namespace Gay.Silverbranch.Api.Sql.ValueConverters;

public class DictionaryStringStringToJsonConverter: ValueConverter<Dictionary<string, string>?, string?>
{
    public DictionaryStringStringToJsonConverter() :
        base(dict => SerializeDictionary(dict!),
        str => DeserializeStringToDictionary(str!))
    {
    }

    private static Dictionary<string, string>? DeserializeStringToDictionary(string str)
    {
        if (string.IsNullOrWhiteSpace(str)) return new Dictionary<string, string>();
        return JsonSerializer.Deserialize<Dictionary<string, string>>(str);
    }

    private static string? SerializeDictionary(Dictionary<string, string> dict)
    {
        if (dict.IsNullOrEmpty()) return null;
        return JsonSerializer.Serialize(dict);
    }
}