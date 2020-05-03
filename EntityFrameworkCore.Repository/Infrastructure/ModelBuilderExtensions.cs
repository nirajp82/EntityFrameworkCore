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
            Guid student1Id = Guid.NewGuid();
            Guid student2Id = Guid.NewGuid();
            Guid student3Id = Guid.NewGuid();

            Guid subject1Id = Guid.NewGuid();
            Guid subject2Id = Guid.NewGuid();
            Guid subject3Id = Guid.NewGuid();
            Guid subject4Id = Guid.NewGuid();

            Guid evaluation1Id = Guid.NewGuid();
            Guid evaluation2Id = Guid.NewGuid();
            Guid evaluation3Id = Guid.NewGuid();
            Guid evaluation4Id = Guid.NewGuid();

            #region Create Subjects
            modelBuilder.Entity<Subject>().HasData(
                  new Subject
                  {
                      Id = subject1Id,
                      SubjectName = ".Net Core"
                  });

            modelBuilder.Entity<Subject>().HasData(
               new Subject
               {
                   Id = subject2Id,
                   SubjectName = "Data Structure"
               });

            modelBuilder.Entity<Subject>().HasData(
               new Subject
               {
                   Id = subject3Id,
                   SubjectName = "SQL Server"
               });
            modelBuilder.Entity<Subject>().HasData(
               new Subject
               {
                   Id = subject4Id,
                   SubjectName = "MS Azure"
               });
            #endregion


            #region Create Students
            #region Create Student 1
            modelBuilder.Entity<Student>().HasData(
                   new Student
                   {
                       Id = student1Id,
                       FirstName = "Maheraj",
                       LastName = "Thakur",
                       Age = 37
                   });

            modelBuilder.Entity<StudentDetail>().HasData(
                new StudentDetail
                {
                    Id = Guid.NewGuid(),
                    Address = "Some Street",
                    StudentId = student1Id
                });

            modelBuilder.Entity<Evaluation>().HasData(
               new Evaluation
               {
                   Id = evaluation1Id,
                   Grade = 12,
                   AdditionalExplanation = "Excellent",
                   StudentId = student1Id
               });

            modelBuilder.Entity<Evaluation>().HasData(
               new Evaluation
               {
                   Id = evaluation2Id,
                   Grade = 11,
                   AdditionalExplanation = "Outstanding",
                   StudentId = student1Id
               });

            modelBuilder.Entity<Evaluation>().HasData(
              new Evaluation
              {
                  Id = evaluation4Id,
                  Grade = 12,
                  AdditionalExplanation = "Very good",
                  StudentId = student1Id
              });

            modelBuilder.Entity<StudentSubject>().HasData(
             new StudentSubject
             {
                 StudentId = student1Id,
                 SubjectId = subject1Id
             });

            modelBuilder.Entity<StudentSubject>().HasData(
             new StudentSubject
             {
                 StudentId = student1Id,
                 SubjectId = subject2Id
             });

            modelBuilder.Entity<StudentSubject>().HasData(
             new StudentSubject
             {
                 StudentId = student1Id,
                 SubjectId = subject3Id
             });
            #endregion


            #region Create Student 2
            modelBuilder.Entity<Student>().HasData(
                  new Student
                  {
                      Id = student2Id,
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
                    StudentId = student2Id
                });

            modelBuilder.Entity<Evaluation>().HasData(
               new Evaluation
               {
                   Id = evaluation3Id,
                   Grade = 11,
                   AdditionalExplanation = "Satisfactory",
                   StudentId = student2Id
               });

            modelBuilder.Entity<StudentSubject>().HasData(
             new StudentSubject
             {
                 StudentId = student2Id,
                 SubjectId = subject1Id
             });

            modelBuilder.Entity<StudentSubject>().HasData(
             new StudentSubject
             {
                 StudentId = student2Id,
                 SubjectId = subject2Id
             });
            #endregion


            #region Create Student 3
            modelBuilder.Entity<Student>().HasData(
                  new Student
                  {
                      Id = student3Id,
                      FirstName = "Virat",
                      LastName = "Kohli",
                      Age = 27
                  });
            modelBuilder.Entity<StudentDetail>().HasData(
               new StudentDetail
               {
                   Id = Guid.NewGuid(),
                   Address = "Delhi",
                   StudentId = student3Id
               });

            modelBuilder.Entity<StudentSubject>().HasData(
             new StudentSubject
             {
                 StudentId = student3Id,
                 SubjectId = subject1Id
             });

            modelBuilder.Entity<StudentSubject>().HasData(
             new StudentSubject
             {
                 StudentId = student3Id,
                 SubjectId = subject2Id
             });

            modelBuilder.Entity<StudentSubject>().HasData(
             new StudentSubject
             {
                 StudentId = student3Id,
                 SubjectId = subject3Id
             });

            modelBuilder.Entity<StudentSubject>().HasData(
             new StudentSubject
             {
                 StudentId = student3Id,
                 SubjectId = subject4Id
             });
            #endregion 
            #endregion
        }

        private static void CreateSubjects(ModelBuilder modelBuilder)
        {

        }
        #endregion
    }
}
