using Gay.Silverbranch.API.Models.Entities.V1;
using Gay.Silverbranch.Api.Sql.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gay.Silverbranch.Api.Sql.EntityMapping.Models.V1;

public class PersonModelEntityMapping : BaseModelMapping<PersonModel>
{
    public new const string TableName = "Person";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    // https://learn.microsoft.com/en-us/sql/t-sql/data-types/data-types-transact-sql?view=sql-server-ver16
    public override void Configure(EntityTypeBuilder<PersonModel> builder)
    {
        // builder.ToTable(TABLENAME)
        //     .HasKey(x => x.EntryIdentity);

        builder.Property(x => x.PreferedName)
            .HasColumnType("nvarchar")
            .HasMaxLength(512);

        builder.Property(x => x.Pronouns)
            .HasConversion(new ListPronounToIntArrayConverter());
        
        builder.Property(x => x.Website)
            .HasColumnType("ntext")
            .HasColumnName("Link");

        builder.HasMany(person => person.Addresses)
            .WithMany()
            .UsingEntity("AddressOfPerson",
                left => left.HasOne(typeof(AddressModel))
                            .WithMany()
                            .HasForeignKey("AddressId")
                            //.HasPrincipalKey(nameof(AddressModel.CommonIdentity))
                            .HasConstraintName("FK_AddressOfPerson_Address")
                            .OnDelete(DeleteBehavior.Cascade),
                right => right.HasOne(typeof(PersonModel))
                            .WithMany()
                            .HasForeignKey("PersonId")
                            //.HasPrincipalKey(nameof(PersonModel.CommonIdentity))
                            .HasConstraintName("FK_AddressOfPerson_Person")
                            .OnDelete(DeleteBehavior.Cascade),
                linkBuilder => linkBuilder.HasKey("AddressId", "PersonId")
                );
    }
}