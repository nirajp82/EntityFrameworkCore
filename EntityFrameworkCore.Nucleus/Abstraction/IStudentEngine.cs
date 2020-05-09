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
        StudentEntity Add(StudentEntity entity);
        Task<StudentEntity> Update(StudentEntity entity);
        Task DeleteAsync(long studentId);
    }
}
