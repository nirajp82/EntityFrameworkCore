using EntityFrameworkCore.APIModel;
using EntityFrameworkCore.DataModel;
using EntityFrameworkCore.Repository;
using System;
using System.Collections.Generic;

namespace EntityFrameworkCore.Nucleus
{
    public class StudentEngine : IStudentEngine
    {
        #region Members
        private IUnitOfWork _unitOfWork { get; }
        private IMapperHelper _mapperHelper { get; }
        #endregion


        #region Constructors
        public StudentEngine(IUnitOfWork unitOfWork, IMapperHelper mapperHelper)
        {
            _unitOfWork = unitOfWork;
            _mapperHelper = mapperHelper;
        }
        #endregion


        #region Public Methods
        public void Create(StudentEntity entity)
        {
            Student student = _mapperHelper.Map<StudentEntity, Student>(entity);
            _unitOfWork.StudentRepository.Create(student);
        }

        public void Delete(StudentEntity entity)
        {
            Student student = _mapperHelper.Map<StudentEntity, Student>(entity);
            _unitOfWork.StudentRepository.Delete(student);
        }

        public StudentEntity Find(Guid studentId)
        {
            Student student = _unitOfWork.StudentRepository.FindFirst(s => s.StudentId == studentId);
            return _mapperHelper.Map<Student, StudentEntity>(student);
        }

        public IEnumerable<StudentEntity> FindAll()
        {
            IEnumerable<Student> students = _unitOfWork.StudentRepository.FindAll();
            return _mapperHelper.MapList<Student, StudentEntity>(students);
        }

        public void Update(StudentEntity entity)
        {
            Student student = _mapperHelper.Map<StudentEntity, Student>(entity);
            _unitOfWork.StudentRepository.Update(student);
        }
        #endregion
    }
}
