using Gay.Silverbranch.API.Models.Entities.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gay.Silverbranch.Api.SQL.EntityMapping.Models.V1;

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