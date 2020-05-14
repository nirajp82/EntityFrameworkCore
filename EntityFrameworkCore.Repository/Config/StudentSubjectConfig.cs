using EntityFrameworkCore.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Repository
{
    internal class StudentSubjectConfig : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            //builder.HasKey(ss => new { ss.StudentId, ss.SubjectId });

            builder.HasOne(ss => ss.Student)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.StudentId);

            builder.HasOne(ss => ss.Subject)
                .WithMany(ss => ss.StudentSubjects)
                .HasForeignKey(ss => ss.SubjectId);
        }
    }
}
