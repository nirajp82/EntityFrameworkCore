using EntityFrameworkCore.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Repository
{
    internal static class ModelBuilderExtensions
    {
        #region Public Method
        internal static void Seed(this ModelBuilder modelBuilder)
        {
            CreateStudents(modelBuilder);

            CreateSubjects(modelBuilder);
        }
        #endregion


        #region Private Methods
        private static void CreateStudents(ModelBuilder modelBuilder)
        {
            Guid studentId = Guid.NewGuid();
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = studentId,
                    FirstName = "Maheraj",
                    LastName = "Thakur",
                    Age = 37
                });

            modelBuilder.Entity<StudentDetail>().HasData(
                new StudentDetail
                {
                    Id = Guid.NewGuid(),
                    Address = "Some Street",
                    StudentId = studentId
                });

            studentId = Guid.NewGuid();
            modelBuilder.Entity<Student>().HasData(
               new Student
               {
                   Id = studentId,
                   FirstName = "Sachin",
                   MiddleInitial = "R",
                   LastName = "Tendulkar",
                   Age = 42
               });
            modelBuilder.Entity<StudentDetail>().HasData(
                new StudentDetail
                {
                    Id = Guid.NewGuid(),
                    Address = "Mumbai",
                    StudentId = studentId
                });


            studentId = Guid.NewGuid();
            modelBuilder.Entity<Student>().HasData(
               new Student
               {
                   Id = studentId,
                   FirstName = "Virat",
                   LastName = "Kohli",
                   Age = 27
               });
            modelBuilder.Entity<StudentDetail>().HasData(
               new StudentDetail
               {
                   Id = Guid.NewGuid(),
                   Address = "Delhi",
                   StudentId = studentId
               });
        }

        private static void CreateSubjects(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>().HasData(
               new Subject
               {
                   Id = Guid.NewGuid(),
                   SubjectName = ".Net Core"
               });

            modelBuilder.Entity<Subject>().HasData(
               new Subject
               {
                   Id = Guid.NewGuid(),
                   SubjectName = "Data Structure"
               });

            modelBuilder.Entity<Subject>().HasData(
               new Subject
               {
                   Id = Guid.NewGuid(),
                   SubjectName = "SQL Server"
               });
        }
        #endregion
    }
}
