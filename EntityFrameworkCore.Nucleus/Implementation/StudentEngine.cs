using EntityFrameworkCore.APIModel;
using EntityFrameworkCore.DataModel;
using EntityFrameworkCore.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Nucleus
{
    internal class StudentEngine : IStudentEngine
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
        public void AddAsync(StudentEntity entity)
        {
            Student student = _mapperHelper.Map<StudentEntity, Student>(entity);
            _unitOfWork.StudentRepository.AddAsync(student);
        }

        public void Delete(StudentEntity entity)
        {
            Student student = _mapperHelper.Map<StudentEntity, Student>(entity);
            _unitOfWork.StudentRepository.Delete(student);
        }

        public async Task<StudentEntity> FindAsync(Guid studentId)
        {
            Student student = await _unitOfWork.StudentRepository.FindFirstAsync(s => s.Id == studentId);
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
