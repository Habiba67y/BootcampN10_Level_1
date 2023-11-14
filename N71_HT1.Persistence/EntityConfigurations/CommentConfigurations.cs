using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N71_HT1.DoMain.Entities;

namespace N71_HT1.Persistence.EntityConfigurations;

public class CommentConfigurations : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasOne<Blog>().WithMany(blog => blog.Comments).HasForeignKey(comment => comment.BlogId);
    }
}
