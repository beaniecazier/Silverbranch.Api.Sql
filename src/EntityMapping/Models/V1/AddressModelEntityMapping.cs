using Gay.Silverbranch.API.Models.Entities.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gay.Silverbranch.Api.Sql.EntityMapping.Models.V1;

public class AddressModelEntityMapping : BaseModelMapping<AddressModel>
{
    public new const string TableName = "Address";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    // https://learn.microsoft.com/en-us/sql/t-sql/data-types/data-types-transact-sql?view=sql-server-ver16
    public override void Configure(EntityTypeBuilder<AddressModel> builder)
    {
        builder.ToTable(TableName)
            .HasKey(x => x.EntryIdentity);

        builder.Property(x => x.CrossStreetName)
            .HasColumnType("nvarchar")
            .HasMaxLength(256);

        builder.Property(x => x.HouseNumber)
            .HasColumnType("smallint")
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(x => x.PrefixDirection)
            .HasColumnType("nvarchar")
            .HasMaxLength(8);

        builder.Property(x => x.PrefixType)
            .HasColumnType("nvarchar")
            .HasMaxLength(64);

        builder.Property(x => x.StreetName)
            .HasColumnType("nvarchar")
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(x => x.StreetType)
            .HasColumnType("nvarchar")
            .HasMaxLength(64)
            .IsRequired();

        builder.Property(x => x.SuffixDirection)
            .HasColumnType("nvarchar")
            .HasMaxLength(8);

        builder.Property(x => x.SuffixType)
            .HasColumnType("nvarchar")
            .HasMaxLength(64);

        builder.Property(x => x.City)
            .HasColumnType("nvarchar")
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(x => x.Region)
            .HasColumnType("nvarchar")
            .HasMaxLength(256);

        builder.Property(x => x.State)
            .HasColumnType("nvarchar")
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(x => x.Country)
            .HasColumnType("nvarchar")
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(x => x.PostalCode)
            .HasColumnType("int")
            .IsRequired();

        builder.Property(x => x.Zip4)
            .HasColumnType("int");

        base.Configure(builder);
    }
}