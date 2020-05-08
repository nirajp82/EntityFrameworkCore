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
        public IEnumerable<Student> FindAll()
        {
            IEnumerable<string> includes = new List<string>{
                                                    nameof(Student.StudentAddress),
                                                    nameof(Student.StudentEnrollments),
                                                    nameof(Student.StudentSubjects)
                                                };
            return base.FindAll(includes);
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

        public IEnumerable<Student> ExecuteProcedure()
        {
            var firstNameParam = new SqlParameter("firstName", "Sachin");

            return _context.Student
                    .FromSqlRaw("EXECUTE dbo.GetMostPopularBlogsForUser @filterByUser=@firstName", firstNameParam)
                    .ToList();
        }

        public IEnumerable<Student> ExecuteTableValuedFunction()
        {
            var searchTerm = "SQL";

            return _context.Student
                .FromSqlInterpolated($"SELECT * FROM dbo.SearchStudentBySubject({searchTerm})")
                .Include(b => b.StudentEnrollments)
                .Where(b => b.Age > 13)
                .AsNoTracking()
                .ToList();
        }       
        #endregion
    }
}
