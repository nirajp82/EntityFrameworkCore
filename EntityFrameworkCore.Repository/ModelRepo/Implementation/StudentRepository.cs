using EntityFrameworkCore.DataModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Repository
{
    internal class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        #region Constructor
        public StudentRepository(ApplicationContext context) : base(context)
        {
        }
        #endregion


        #region Public Method
        public async Task<IEnumerable<Student>> FindAllAsync()
        {
            IEnumerable<string> includes = new List<string>{
                                                    nameof(Student.StudentAddress),
                                                    nameof(Student.StudentEnrollments),
                                                    nameof(Student.StudentSubjects)
                                                };
            return await base.FindAll(includes).ToListAsync();
        }

        public async Task<Student> FindFirstAsync(long studentId)
        {
            IEnumerable<string> includes = new List<string>{
                                                    nameof(Student.StudentAddress),
                                                    nameof(Student.StudentEnrollments),
                                                };
            IQueryable<Student> queryable = base.Find(s => s.Id == studentId, includes, isNoTracking: false);
            return await queryable.Include(s => s.StudentSubjects)
                    .ThenInclude(ss => ss.Subject).FirstOrDefaultAsync();
        }

        public async Task<Student> UpdateAsync(Student entity)
        {
            Student dbStudent = await FindFirstAsync(entity.Id);
            UpdateStudent(dbStudent, entity);
            return dbStudent;
        }

        //public IEnumerable<Student> ExecuteProcedure()
        //{
        //    var firstNameParam = new SqlParameter("firstName", "Sachin");

        //    return _context.Student
        //            .FromSqlRaw("EXECUTE dbo.GetMostPopularBlogsForUser @filterByUser=@firstName", firstNameParam)
        //            .ToList();
        //}

        //public IEnumerable<Student> ExecuteTableValuedFunction()
        //{
        //    var searchTerm = "SQL";

        //    return _context.Student
        //        .FromSqlInterpolated($"SELECT * FROM dbo.SearchStudentBySubject({searchTerm})")
        //        .Include(b => b.StudentEnrollments)
        //        .Where(b => b.Age > 13)
        //        .AsNoTracking()
        //        .ToList();
        //}
        #endregion


        #region Private Methods
        private void UpdateStudent(Student dbStudent, Student entity)
        {
            dbStudent.Age = entity.Age;
            dbStudent.FirstName = entity.FirstName;
            dbStudent.MiddleInitial = entity.MiddleInitial;
            dbStudent.LastName = entity.LastName;
            dbStudent.StudentAddress = entity.StudentAddress;
            UpdateSubject(dbStudent, entity);
            UpdateEnrollment(dbStudent, entity);
        }

        private void UpdateSubject(Student dbStudent, Student entity)
        {
            //Remove all Student Subjects
            if (entity.StudentSubjects == null)
            {
                dbStudent.StudentSubjects = null;
                return;
            }

            //Add All Student subjects
            if (dbStudent.StudentSubjects == null)
            {
                dbStudent.StudentSubjects = entity.StudentSubjects;
                return;
            }

            //Merge(Add/Update/Delete) Subjects
            IEnumerable<long> dbSubIdList = dbStudent.StudentSubjects.Select(ss => ss.Id).ToList();
            IEnumerable<long> entitySubIdList = entity.StudentSubjects.Select(ss => ss.Id);

            //Remove subjects.
            foreach (var dbSubId in dbSubIdList.Where(dss => !entitySubIdList.Contains(dss)))
                dbStudent.StudentSubjects.Remove(dbStudent.StudentSubjects.FirstOrDefault(ss => ss.Id == dbSubId));


            //Add/Update StudentEnrollments
            foreach (var sSubEntity in entity.StudentSubjects)
            {
                if (sSubEntity.Id == 0)
                    dbStudent.StudentSubjects.Add(sSubEntity);
                else
                {
                    var dbStudentSubject = dbStudent.StudentSubjects.FirstOrDefault(e => e.Id == sSubEntity.Id);
                    if (dbStudentSubject != null)
                        dbStudentSubject.SubjectId = sSubEntity.SubjectId;
                }
            }

        }

        private void UpdateEnrollment(Student dbStudent, Student entity)
        {
            //Remove all Student Subjects
            if (entity.StudentEnrollments == null)
            {
                dbStudent.StudentEnrollments = null;
                return;
            }

            //Add All Student subjects
            if (dbStudent.StudentEnrollments == null)
            {
                dbStudent.StudentEnrollments = entity.StudentEnrollments;
                return;
            }

            //Merge(Add/Update/Delete) Enrollments
            IEnumerable<long> dbEnrollIdList = dbStudent.StudentEnrollments.Select(ss => ss.Id).ToList();
            IEnumerable<long> entityEnrollIdList = entity.StudentEnrollments.Select(ss => ss.Id);

            //Remove StudentEnrollments.
            foreach (var dbEvalId in dbEnrollIdList.Where(dss => !entityEnrollIdList.Contains(dss)))
                dbStudent.StudentEnrollments.Remove(dbStudent.StudentEnrollments.FirstOrDefault(ss => ss.Id == dbEvalId));

            //Add/Update StudentEnrollments
            foreach (var sEnrollEntity in entity.StudentEnrollments)
            {
                if (sEnrollEntity.Id == 0)
                    dbStudent.StudentEnrollments.Add(sEnrollEntity);
                else
                {
                    var dbStudentEnrollment = dbStudent.StudentEnrollments.FirstOrDefault(e => e.Id == sEnrollEntity.Id);
                    if (dbStudentEnrollment != null)
                    {
                        dbStudentEnrollment.Grade = sEnrollEntity.Grade;
                        dbStudentEnrollment.AdditionalExplanation = sEnrollEntity.AdditionalExplanation;
                    }
                }
            }
        }
        #endregion
    }
}