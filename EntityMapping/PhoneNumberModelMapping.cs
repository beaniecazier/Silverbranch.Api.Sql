using BeaniesUtilities.Models.CommonModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BeaniesUtilities.SQLDataOperations.EntityMapping;

public class PhoneNumberModelMapping : BaseModelMapping<PhoneNumberModel>
{
    public new const string TABLENAME = "PhoneNumbers";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    // https://learn.microsoft.com/en-us/sql/t-sql/data-types/data-types-transact-sql?view=sql-server-ver16
    public override void Configure(EntityTypeBuilder<PhoneNumberModel> builder)
    {
        builder.ToTable(TABLENAME)
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