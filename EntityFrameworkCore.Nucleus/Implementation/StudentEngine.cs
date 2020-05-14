using EntityFrameworkCore.APIModel;
using EntityFrameworkCore.DataModel;
using EntityFrameworkCore.Repository;
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
            _unitOfWork.StudentRepository.Add(student);
            await _unitOfWork.SaveAsync();
            return _mapperHelper.Map<Student, StudentEntity>(student);
        }

        public async Task DeleteAsync(long studentId)
        {
            await _unitOfWork.StudentRepository.DeleteAsync(studentId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<StudentEntity> FindAsync(long studentId)
        {
            Student student = await _unitOfWork.StudentRepository.FindFirstAsync(studentId);
            return _mapperHelper.Map<Student, StudentEntity>(student);
        }

        public async Task<IEnumerable<StudentEntity>> FindAllAsync()
        {
            IEnumerable<Student> students = await _unitOfWork.StudentRepository.FindAllAsync();
            return _mapperHelper.MapList<Student, StudentEntity>(students);
        }

        public async Task<StudentEntity> UpdateAsync(StudentEntity entity)
        {
            Student student = _mapperHelper.Map<StudentEntity, Student>(entity);
            student = await _unitOfWork.StudentRepository.UpdateAsync(student);
            await _unitOfWork.SaveAsync();
            return _mapperHelper.Map<Student, StudentEntity>(student);
        }
        #endregion    
    }
}
