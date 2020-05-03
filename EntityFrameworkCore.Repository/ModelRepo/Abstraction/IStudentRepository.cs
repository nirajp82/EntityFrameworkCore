using EntityFrameworkCore.DataModel;
using System;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Repository
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        Task<Student> FindFirstIncludeAllAsync(Guid studentId);
    }
}
