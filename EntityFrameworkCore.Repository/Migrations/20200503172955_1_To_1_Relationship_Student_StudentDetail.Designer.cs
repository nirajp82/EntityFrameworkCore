﻿// <auto-generated />
using System;
using EntityFrameworkCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameworkCore.Repository.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20200503172955_1_To_1_Relationship_Student_StudentDetail")]
    partial class _1_To_1_Relationship_Student_StudentDetail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("MiddleInitial")
                        .HasColumnType("nvarchar(1)")
                        .HasMaxLength(1);

                    b.HasKey("Id");

                    b.HasIndex("LastName", "FirstName")
                        .HasName("idxStudentLFName");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EntityFrameworkCore.DataModel.StudentDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("StudentDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdditionalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("StudentDetail");
                });

            modelBuilder.Entity("EntityFrameworkCore.DataModel.StudentDetail", b =>
                {
                    b.HasOne("EntityFrameworkCore.DataModel.Student", "Student")
                        .WithOne("StudentDetail")
                        .HasForeignKey("EntityFrameworkCore.DataModel.StudentDetail", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
