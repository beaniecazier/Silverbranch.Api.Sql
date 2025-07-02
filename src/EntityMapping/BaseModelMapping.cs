using Gay.Silverbranch.API.Models;
using Gay.Silverbranch.API.SQL.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gay.Silverbranch.API.SQL.EntityMapping
{
    public abstract class BaseModelMapping<T> : IEntityTypeConfiguration<T>
    where T : BaseModel
    {
        public const string TableName = "BASEMODELTABLE - DO NOT USE";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        // https://learn.microsoft.com/en-us/sql/t-sql/data-types/data-types-transact-sql?view=sql-server-ver16
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.EntryIdentity)
                .HasColumnOrder(1)
                .HasColumnName("Id");

            builder.Property(x => x.CommonIdentity)
                .HasColumnType("varchar")
                .HasMaxLength(13)
                .HasColumnOrder(2)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .HasColumnOrder(3)
                .IsRequired();

            builder.Property(x => x.ModifiedBy)
                .HasColumnType("nvarchar")
                .HasMaxLength(64);

            // builder.Property(x => x.ModifiedOn)
            //     .HasColumnType("char(22)")
            //     .HasConversion(new DateTimeToChar22Converter());
            builder.Property(x => x.ModifiedOn)
                .HasColumnType("datetime2");

            builder.Property(x => x.IsHidden)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(x => x.HiddenBy)
                .HasColumnType("nvarchar")
                .HasMaxLength(64);

            // builder.Property(x => x.HiddenOn)
            //     .HasColumnType("char(22)")
            //     .HasConversion(new DateTimeToChar22Converter());
            builder.Property(x => x.HiddenOn)
                .HasColumnType("datetime2");

            builder.Property(x => x.IsDeleted)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(x => x.DeletedBy)
                .HasColumnType("nvarchar")
                .HasMaxLength(64);

            // builder.Property(x => x.DeletedOn)
            //     .HasColumnType("char(22)")
            //     .HasConversion(new DateTimeToChar22Converter());
            builder.Property(x => x.DeletedOn)
                .HasColumnType("datetime2");

            builder.Property(x => x.Notes)
                .HasColumnType("ntext")
                .IsRequired();

            builder.HasQueryFilter(x => !x.IsDeleted && !x.IsHidden);
        }
    }
}