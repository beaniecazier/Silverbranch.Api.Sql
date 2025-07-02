using Gay.Silverbranch.API.Models.CommonModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gay.Silverbranch.API.SQL.EntityMapping.CommonModels;

public class CountryCodeModelEntityMapping : BaseModelMapping<CountryCodeModel>
{
    public new const string TableName = "CountryCodes";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    // https://learn.microsoft.com/en-us/sql/t-sql/data-types/data-types-transact-sql?view=sql-server-ver16
    public override void Configure(EntityTypeBuilder<CountryCodeModel> builder)
    {
        builder.ToTable(TableName)
            .HasKey(x => x.EntryIdentity);

        builder.Property(x => x.Country)
            .HasColumnType("nvarchar")
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(x => x.CallingCode)
            .HasColumnType("nvarchar")
            .HasMaxLength(8)
            .IsRequired();

        builder.Property(x => x.Iso3Letter)
            .HasColumnType("nvarchar")
            .HasMaxLength(3)
            .IsRequired();

        builder.Property(x => x.Iso2Letter)
            .HasColumnType("nvarchar")
            .HasMaxLength(2)
            .IsRequired();

        builder.Property(x => x.IsoNumeric)
            .HasColumnType("smallint")
            .IsRequired();

        base.Configure(builder);
    }
}