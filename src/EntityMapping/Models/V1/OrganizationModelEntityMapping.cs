using Gay.Silverbranch.API.Models.Entities.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gay.Silverbranch.Api.Sql.EntityMapping.Models.V1;

public class OrganizationModelEntityMapping : BaseModelMapping<OrganizationModel>
{
    public new const string TableName = "Organizations";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    // https://learn.microsoft.com/en-us/sql/t-sql/data-types/data-types-transact-sql?view=sql-server-ver16
    public override void Configure(EntityTypeBuilder<OrganizationModel> builder)
    {
        // builder.ToTable(TABLENAME)
        //     .HasKey(x => x.EntryIdentity);

        builder.Property(x => x.Industry)
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(x => x.Status)
            .HasColumnType("smallint")
            .IsRequired();

        builder.HasMany(person => person.Addresses)
            .WithMany()
            .UsingEntity("AddressOfOrganization",
                left => left.HasOne(typeof(AddressModel))
                    .WithMany()
                    .HasForeignKey("AddressId")
                    //.HasPrincipalKey(nameof(AddressModel.CommonIdentity))
                    .HasConstraintName("FK_AddressOfOrganization_Address")
                    .OnDelete(DeleteBehavior.Cascade),
                right => right.HasOne(typeof(OrganizationModel))
                    .WithMany()
                    .HasForeignKey("OrganizationId")
                    //.HasPrincipalKey(nameof(OrganizationModel.CommonIdentity))
                    .HasConstraintName("FK_AddressOfOrganization_Organization")
                    .OnDelete(DeleteBehavior.Cascade),
                linkBuilder => linkBuilder.HasKey("AddressId", "OrganizationId")
            );
        
        builder.Property(x => x.Website)
            .HasColumnType("ntext")
            .HasColumnName("Link");

        // builder.HasOne(x => x.ParentOrganization)
        //     .WithOne();
        //
        // builder.HasMany(x => x.Subsidiaries)
        //     .WithOne()
        //     .HasForeignKey("ParentOrganizationId");
        
        builder.Property(x => x.Departments);
    }
}