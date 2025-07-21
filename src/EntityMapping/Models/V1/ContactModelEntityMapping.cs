using Gay.Silverbranch.API.Models.Entities.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gay.Silverbranch.Api.Sql.EntityMapping.Models.V1;

public class ContactModelEntityMapping : BaseModelMapping<ContactModel>
{
    public new const string TableName = "ContactInfo";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    // https://learn.microsoft.com/en-us/sql/t-sql/data-types/data-types-transact-sql?view=sql-server-ver16
    public override void Configure(EntityTypeBuilder<ContactModel> builder)
    {
        builder.ToTable(TableName)
            .HasKey(x => x.EntryIdentity);

        builder.Property(x => x.Emails);
        
        builder.Property(x => x.Socials);
        
        builder.HasMany(contact => contact.PhoneNumbers)
            .WithOne()
            .HasForeignKey("ContactInfoId");
            //.HasPrincipalKey(contact => contact.CommonIdentity);
        
        base.Configure(builder);
    }
}