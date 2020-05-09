using EntityFrameworkCore.APIModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Nucleus
{
    public interface IStudentEngine
    {
        Task<IEnumerable<StudentEntity>> FindAllAsync();

        Task<StudentEntity> FindAsync(long studentId);

        Task<StudentEntity> AddAsync(StudentEntity entity);

        Task<StudentEntity> UpdateAsync(StudentEntity entity);

        Task DeleteAsync(long studentId);
    }
}
