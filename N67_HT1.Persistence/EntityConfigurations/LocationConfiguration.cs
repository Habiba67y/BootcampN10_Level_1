using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N67_HT1.DoMain.Entites;

namespace N67_HT1.Persistence.EntityConfigurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.Property(location => location.Name).IsRequired().HasMaxLength(256);

        builder
            .HasMany(location => location.Users)
            .WithOne(user => user.Location);
    }
}
