using EntityFrameworkCore.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Repository
{
    internal class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        #region Constructor
        private IModelHelper _modelHelper { get; }
        #endregion


        #region Constructor
        public StudentRepository(ApplicationContext context, IModelHelper modelHelper) : base(context)
        {
            _modelHelper = modelHelper;
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
            static void delSrcDestMapper(StudentSubject src, StudentSubject dbModel)
            {
                dbModel.SubjectId = src.SubjectId;
            }
            dbStudent.StudentSubjects = _modelHelper.MergeList(entity.StudentSubjects, dbStudent.StudentSubjects, delSrcDestMapper);
        }

        private void UpdateEnrollment(Student dbStudent, Student entity)
        {
            static void delSrcDestMapper(StudentEnrollment src, StudentEnrollment dbModel)
            {
                dbModel.Grade = src.Grade;
                dbModel.AdditionalExplanation = src.AdditionalExplanation;
            }
            dbStudent.StudentEnrollments = _modelHelper.MergeList(entity.StudentEnrollments,
                dbStudent.StudentEnrollments, delSrcDestMapper);
        }
        #endregion
    }
}