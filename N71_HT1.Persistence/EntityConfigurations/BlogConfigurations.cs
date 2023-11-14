using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N71_HT1.DoMain.Entities;

namespace N71_HT1.Persistence.EntityConfigurations;

public class BlogConfigurations : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasOne<User>().WithMany(blogger => blogger.Blogs).HasForeignKey(blog => blog.BloggerId);
    }
}
