using EntityFrameworkCore.APIModel;
using System;
using System.Collections.Generic;

namespace EntityFrameworkCore.Nucleus
{
    public interface IStudentEngine
    {
        IEnumerable<StudentEntity> FindAll();
        StudentEntity Find(Guid studentId);
        void Create(StudentEntity entity);
        void Update(StudentEntity entity);
        void Delete(StudentEntity entity);
    }
}
