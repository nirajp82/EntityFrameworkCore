using EntityFrameworkCore.DataModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Repository
{
    public interface IStudentRepository
    {
        void Add(Student entity);

        void Update(Student entity);

        Task DeleteAsync(long studentId);

        Task<Student> FindFirstAsync(long studentId);

        IEnumerable<Student> FindAll();
    }
}
