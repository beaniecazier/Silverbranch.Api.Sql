using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using Version = Gay.Silverbranch.Utilities.General.Version;

namespace Gay.Silverbranch.API.SQL.ValueConverters;

public class VersionToStringConverter : ValueConverter<Version, string>
{
    public VersionToStringConverter() :
        base(version => VersionToString(version),
            str => VersionFromString(str))
    {
    }
    
    private static string VersionToString(Version version)
        => version.Major + "." + version.Minor + "." + version.Build;

    private static Version VersionFromString(string version)
    {
        var versionParts = version.Split('.');
        
        var major = int.Parse(versionParts[0]);
        var minor = int.Parse(versionParts[1]);
        var patch = int.Parse(versionParts[2]);
        
        return new Version()
        {
            Major = major,
            Minor = minor,
            Patch = patch
        };
    }
}