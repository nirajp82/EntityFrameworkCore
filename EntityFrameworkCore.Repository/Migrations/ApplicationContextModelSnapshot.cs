﻿// <auto-generated />
using System;
using EntityFrameworkCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameworkCore.Repository.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityFrameworkCore.DataModel.Evaluation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EvaluationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdditionalExplanation")
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Evaluation");
                });

            modelBuilder.Entity("EntityFrameworkCore.DataModel.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("StudentId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Unique id of a student");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<string>("MiddleInitial")
                        .HasColumnType("VARCHAR(1)")
                        .HasMaxLength(1);

                    b.HasKey("Id");

                    b.HasIndex("LastName", "FirstName")
                        .HasName("idxStudentLFName");

                    b.ToTable("Student");

                    b.HasData(
                        new
                        {
                            Id = new Guid("90997e95-52e2-4eb8-a70a-b2f3d6711ef3"),
                            Age = 37,
                            FirstName = "Maheraj",
                            LastName = "Thakur"
                        },
                        new
                        {
                            Id = new Guid("59a13bb7-7de9-4533-83bf-072e3ad37af3"),
                            Age = 42,
                            FirstName = "Sachin",
                            LastName = "Tendulkar"
                        },
                        new
                        {
                            Id = new Guid("9c1d8ac1-5b3f-4429-b331-39365b09ed8a"),
                            Age = 27,
                            FirstName = "Virat",
                            LastName = "Kohli"
                        });
                });

            modelBuilder.Entity("EntityFrameworkCore.DataModel.StudentDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("StudentDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdditionalInformation")
                        .HasColumnType("VARCHAR(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("StudentDetail");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1fac2ab4-4237-40f6-baad-6042ab5495e2"),
                            Address = "Some Street",
                            StudentId = new Guid("90997e95-52e2-4eb8-a70a-b2f3d6711ef3")
                        },
                        new
                        {
                            Id = new Guid("8c03177f-9c73-489a-ace8-604ae967c0c9"),
                            Address = "Mumbai",
                            StudentId = new Guid("59a13bb7-7de9-4533-83bf-072e3ad37af3")
                        },
                        new
                        {
                            Id = new Guid("c2ad9a45-973d-4add-b2dd-65ef7041f397"),
                            Address = "Delhi",
                            StudentId = new Guid("9c1d8ac1-5b3f-4429-b331-39365b09ed8a")
                        });
                });

            modelBuilder.Entity("EntityFrameworkCore.DataModel.StudentSubject", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StudentId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("StudentSubject");
                });

            modelBuilder.Entity("EntityFrameworkCore.DataModel.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SubjectName")
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Subject");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b1306a81-4a93-4ed5-b8c7-b04aeb02c68c"),
                            SubjectName = ".Net Core"
                        },
                        new
                        {
                            Id = new Guid("e4ede75e-9c39-45b2-b484-6f825defd26d"),
                            SubjectName = "Data Structure"
                        },
                        new
                        {
                            Id = new Guid("4d299076-c69b-4bd0-8ee3-58303c90aedc"),
                            SubjectName = "SQL Server"
                        });
                });

            modelBuilder.Entity("EntityFrameworkCore.DataModel.Evaluation", b =>
                {
                    b.HasOne("EntityFrameworkCore.DataModel.Student", "Student")
                        .WithMany("Evaluations")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameworkCore.DataModel.StudentDetail", b =>
                {
                    b.HasOne("EntityFrameworkCore.DataModel.Student", "Student")
                        .WithOne("StudentDetail")
                        .HasForeignKey("EntityFrameworkCore.DataModel.StudentDetail", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameworkCore.DataModel.StudentSubject", b =>
                {
                    b.HasOne("EntityFrameworkCore.DataModel.Student", "Student")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameworkCore.DataModel.Subject", "Subject")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
