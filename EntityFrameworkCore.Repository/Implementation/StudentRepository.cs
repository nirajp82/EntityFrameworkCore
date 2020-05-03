using EntityFrameworkCore.DataModel;

namespace EntityFrameworkCore.Repository
{
    internal class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        #region Constructor
        public StudentRepository(ApplicationContext context) : base(context)
        {
        } 
        #endregion
    }
}
