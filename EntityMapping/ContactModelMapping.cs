using BeaniesUtilities.Models.CommonModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeaniesUtilities.SQLDataOperations.EntityMapping;

public class ContactModelMapping : BaseModelMapping<ContactModel>
{
    public new const string TABLENAME = "ContactInfo";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    // https://learn.microsoft.com/en-us/sql/t-sql/data-types/data-types-transact-sql?view=sql-server-ver16
    public override void Configure(EntityTypeBuilder<ContactModel> builder)
    {
        builder.ToTable(TABLENAME)
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