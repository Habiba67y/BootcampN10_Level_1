using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N64_T2.Identity.DoMain.Entities;

namespace N64_T2.Identity.Persistence.EntityComfigurations;

public class RoleConfigurations : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasIndex(role => role.RoleType).IsUnique();
    }
}
