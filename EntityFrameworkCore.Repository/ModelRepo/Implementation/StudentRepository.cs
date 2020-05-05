using EntityFrameworkCore.DataModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<Student> FindFirstIncludeAllAsync(long studentId)
        {
            return await _context.Student.Where(s => s.Id == studentId)
                                .Include(s => s.Evaluations)
                                .Include(s => s.StudentAddress)
                                .Include(s => s.StudentSubjects)
                                .ThenInclude(ss => ss.Subject)
                                .FirstOrDefaultAsync();
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
                .Include(b => b.Evaluations)
                .Where(b => b.Age > 13)
                .AsNoTracking()
                .ToList();
        }
        #endregion
    }
}
