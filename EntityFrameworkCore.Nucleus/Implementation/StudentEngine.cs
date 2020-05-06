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
        public async Task<StudentEntity> AddAsync(StudentEntity entity)
        {
            Student student = _mapperHelper.Map<StudentEntity, Student>(entity);
            await _unitOfWork.StudentRepository.AddAsync(student);
            _unitOfWork.Save();
            return _mapperHelper.Map<Student, StudentEntity>(student);
        }

        public async Task DeleteAsync(long studentId)
        {
            Student student = await _unitOfWork.StudentRepository.FindFirstAsync(e => e.Id == studentId);
            _unitOfWork.StudentRepository.Delete(student);
            _unitOfWork.Save();
        }

        public async Task<StudentEntity> FindAsync(long studentId)
        {
            Student student = await _unitOfWork.StudentRepository.FindFirstIncludeAllAsync(studentId);
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
            _unitOfWork.Save();
        }
        #endregion
    }
}
