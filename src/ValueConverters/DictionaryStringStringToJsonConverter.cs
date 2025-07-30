using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.IdentityModel.Tokens;

namespace Gay.Silverbranch.Api.Sql.ValueConverters;

public class DictionaryStringStringToJsonConverter: ValueConverter<Dictionary<string, string>, string>
{
    public DictionaryStringStringToJsonConverter() :
        base(dict => SerializeDictionary(dict, null),
        str => DeserializeStringToDictionary(str, null))
    {
    }

    private static Dictionary<string, string> DeserializeStringToDictionary(
        string str,
        JsonSerializerOptions? options = null)
    {
        if (string.IsNullOrWhiteSpace(str)) return new Dictionary<string, string>();
        return JsonSerializer.Deserialize<Dictionary<string, string>>(str, options)!;
    }

    private static string SerializeDictionary(
        Dictionary<string, string> dict,
        JsonSerializerOptions? options = null) =>
    dict.IsNullOrEmpty() ? string.Empty : JsonSerializer.Serialize(dict);
}