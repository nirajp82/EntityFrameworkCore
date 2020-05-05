using EntityFrameworkCore.APIModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Nucleus
{
    public interface IStudentEngine
    {
        IEnumerable<StudentEntity> FindAll();
        Task<StudentEntity> FindAsync(long studentId);
        Task<long> AddAsync(StudentEntity entity);
        void Update(StudentEntity entity);
        Task DeleteAsync(long studentId);
    }
}
