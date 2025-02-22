using BeaniesUtilities.Models;
using BeaniesUtilities.SQLDataOperations.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeaniesUtilities.SQLDataOperations.EntityMapping
{
    public abstract class BaseModelMapping<T> : IEntityTypeConfiguration<T>
        where T : BaseModel
    {
        public const string TABLENAME = "BASEMODELTABLE - DO NOT USE";

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
                .HasColumnType("int")
                .HasColumnOrder(2)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(512)
                .HasColumnOrder(3)
                .IsRequired();

            builder.Property(x => x.ModifiedBy)
                .HasColumnType("nvarchar")
                .HasMaxLength(512);

            builder.Property(x => x.ModifiedOn)
                .HasColumnType("char(22)")
                .HasConversion(new DateTimeToChar22Converter());

            builder.Property(x => x.IsHidden)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(x => x.HiddenBy)
                .HasColumnType("nvarchar")
                .HasMaxLength(512);

            builder.Property(x => x.HiddenOn)
                .HasColumnType("char(22)")
                .HasConversion(new DateTimeToChar22Converter());

            builder.Property(x => x.IsDeleted)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(x => x.DeletedBy)
                .HasColumnType("nvarchar")
                .HasMaxLength(512);

            builder.Property(x => x.DeletedOn)
                .HasColumnType("char(22)")
                .HasConversion(new DateTimeToChar22Converter());

            builder.Property(x => x.Notes)
                .HasColumnType("ntext")
                .IsRequired();

            builder.HasQueryFilter(x => !x.IsDeleted && !x.IsHidden);
        }
    }
}