using EntityFrameworkCore.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Repository
{
    internal class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasIndex(s => new { s.LastName, s.FirstName })
                    .HasName("idxStudentLFName");

            builder.Property(s => s.Id).HasComment("Unique id of a student");
        }
    }
}
