using EntityFrameworkCore.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Repository
{
    internal class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasMany(e => e.Evaluations)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(s => new { s.LastName, s.FirstName })
                    .HasName("idxStudentLFName");

            builder.Property(s => s.Id).HasComment("Unique id of a student");
        }
    }
}
