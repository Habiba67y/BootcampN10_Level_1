using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N71_HT1.DoMain.Entities;

namespace N71_HT1.Persistence.EntityConfigurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(user => user.FirstName).IsRequired().HasMaxLength(256);
        builder.Property(user => user.LastName).IsRequired().HasMaxLength(256);
        builder.Property(user => user.EmailAddress).IsRequired().HasMaxLength(300);
    }
}
