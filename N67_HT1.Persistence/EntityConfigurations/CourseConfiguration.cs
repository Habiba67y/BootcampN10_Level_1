using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N67_HT1.DoMain.Entites;

namespace N67_HT1.Persistence.EntityConfigurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.Property(course => course.Name).IsRequired().HasMaxLength(300);

        builder.HasOne(course => course.Teacher)
            .WithMany(teacher => teacher.TeacherCourses)
            .HasForeignKey(course => course.TeacherId);
    }
}
