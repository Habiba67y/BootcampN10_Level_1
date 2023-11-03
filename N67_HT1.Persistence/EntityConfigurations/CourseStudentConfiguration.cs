using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N67_HT1.DoMain.Entites;

namespace N67_HT1.Persistence.EntityConfigurations;

public class CourseStudentConfiguration : IEntityTypeConfiguration<CourseStudent>
{
    public void Configure(EntityTypeBuilder<CourseStudent> builder)
    {
        builder.HasKey(cs => new { cs.CourseId, cs.StudentId });

        builder
            .HasOne(cs => cs.Course)
            .WithMany(course => course.CourseStudents)
            .HasForeignKey(cs => cs.CourseId);

        builder
            .HasOne(cs => cs.Student)
            .WithMany(student => student.CourseStudents)
            .HasForeignKey(cs => cs.StudentId);
    }
}
