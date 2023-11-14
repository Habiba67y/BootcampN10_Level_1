using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N64_T2.Identity.DoMain.Entities;

namespace N64_T2.Identity.Persistence.EntityComfigurations;

public class AccessTokenConfiguration : IEntityTypeConfiguration<AccessToken>
{
    public void Configure(EntityTypeBuilder<AccessToken> builder)
    {
        builder.HasOne<User>().WithOne().HasForeignKey<AccessToken>(token => token.UserId);
    }
}
