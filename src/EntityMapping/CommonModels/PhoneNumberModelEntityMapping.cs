using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Gay.Silverbranch.API.Models.CommonModels;

namespace Gay.Silverbranch.API.SQL.EntityMapping.CommonModels;

public class PhoneNumberModelEntityMapping : BaseModelMapping<PhoneNumberModel>
{
    public new const string TableName = "PhoneNumbers";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    // https://learn.microsoft.com/en-us/sql/t-sql/data-types/data-types-transact-sql?view=sql-server-ver16
    public override void Configure(EntityTypeBuilder<PhoneNumberModel> builder)
    {
        builder.ToTable(TableName)
            .HasKey(x => x.EntryIdentity);
        
        builder.Property(x => x.PhoneType)
            .HasConversion<int>()
            .HasColumnType("smallint");

        builder.HasOne(x=>x.CountryCode)
            .WithMany()
            .IsRequired();

        builder.Property(x => x.AreaCode)
            .HasColumnType("varchar(3)")
            .IsRequired();

        builder.Property(x => x.TelephonePrefix)
            .HasColumnType("varchar(3)")
            .IsRequired();

        builder.Property(x => x.LineNumber)
            .HasColumnType("varchar(4)")
            .IsRequired();

        base.Configure(builder);
    }
}