﻿using EntityFrameworkCore.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Repository
{
    public interface IStudentRepository
    {
        void Add(Student entity);

        Task<Student> UpdateAsync(Student entity);

        Task DeleteAsync(long studentId);

        Task<Student> FindFirstAsync(long studentId);

        Task<IEnumerable<Student>> FindAllAsync();
    }
}
