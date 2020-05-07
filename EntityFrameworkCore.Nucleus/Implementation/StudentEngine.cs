using EntityFrameworkCore.APIModel;
using EntityFrameworkCore.DataModel;
using EntityFrameworkCore.Repository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Http.Headers;
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

        public async Task<StudentEntity> Update(StudentEntity entity)
        {
            Student dbStudent = await _unitOfWork.StudentRepository.FindFirstIncludeAllAsync(entity.Id);
            UpdateStudent(dbStudent, entity);
            _unitOfWork.StudentRepository.Update(dbStudent);
            _unitOfWork.Save();
            return _mapperHelper.Map<Student, StudentEntity>(dbStudent);
        }
        #endregion

        #region Private Methods

        private void UpdateStudent(Student dbStudent, StudentEntity entity)
        {
            dbStudent.Age = entity.Age;
            dbStudent.FirstName = entity.FirstName;
            dbStudent.MiddleInitial = entity.MiddleInitial;
            dbStudent.LastName = entity.LastName;
            UpdateStudentAddress(dbStudent, entity);
            UpdateEnrollment(dbStudent, entity);
            UpdateEvaluation(dbStudent, entity);
        }

        private void UpdateStudentAddress(Student dbStudent, StudentEntity entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Address))
            {
                //Delete an Student Address
                dbStudent.StudentAddress = null;
                return;
            }
            dbStudent.StudentAddress = dbStudent.StudentAddress ?? new StudentAddress();
            dbStudent.StudentAddress.Address = entity.Address;
        }

        private void UpdateEnrollment(Student dbStudent, StudentEntity entity)
        {
            //Remove all Student Subjects
            if (entity.StudentSubjects == null)
            {
                dbStudent.StudentSubjects = null;
                return;
            }

            //Add All Student subjects
            if (dbStudent.StudentSubjects == null)
            {
                dbStudent.StudentSubjects = _mapperHelper.MapList<StudentSubjectEntity, StudentSubject>(entity.StudentSubjects).ToList();
                return;
            }

            ManageStudentSubjects(dbStudent, entity);
        }

        private void UpdateEvaluation(Student dbStudent, StudentEntity entity)
        {
            //Remove all Student Subjects
            if (entity.Evaluations == null)
            {
                dbStudent.Evaluations = null;
                return;
            }

            //Add All Student subjects
            if (dbStudent.Evaluations == null)
            {
                dbStudent.Evaluations = _mapperHelper.MapList<EvaluationEntity, Evaluation>(entity.Evaluations).ToList();
                return;
            }

            ManageEvalutions(dbStudent, entity);
        }

        private void ManageStudentSubjects(Student dbStudent, StudentEntity entity)
        {
            IEnumerable<long> dbSubIdList = dbStudent.StudentSubjects.Select(ss => ss.SubjectId).ToList();
            IEnumerable<long> entitySubIdList = entity.StudentSubjects.Select(ss => ss.SubjectId);

            //Remove subjects.
            foreach (var dbSubId in dbSubIdList.Where(dss => !entitySubIdList.Contains(dss)))
            {
                dbStudent.StudentSubjects.Remove(dbStudent.StudentSubjects.FirstOrDefault(ss => ss.SubjectId == dbSubId));
            }

            //Add newly added subjects
            foreach (var eSubId in entitySubIdList.Where(ess => !dbSubIdList.Contains(ess)))
            {
                StudentSubject studentSubject = _mapperHelper.Map<StudentSubjectEntity, StudentSubject>(entity.StudentSubjects.FirstOrDefault(s => s.SubjectId == eSubId));
                dbStudent.StudentSubjects.Add(studentSubject);
            }
        }

        private void ManageEvalutions(Student dbStudent, StudentEntity entity)
        {
            IEnumerable<long> dbEvalList = dbStudent.Evaluations.Select(ss => ss.Id).ToList();
            IEnumerable<long> entityEvalIdList = entity.Evaluations.Select(ss => ss.Id);

            //Remove Evaluations.
            foreach (var dbEvalId in dbEvalList.Where(dss => !entityEvalIdList.Contains(dss)))
                dbStudent.Evaluations.Remove(dbStudent.Evaluations.FirstOrDefault(ss => ss.Id == dbEvalId));

            //Add/Update Evaluations
            foreach (var evaluationEntity in entity.Evaluations)
            {                
                if (evaluationEntity.Id == 0)
                    dbStudent.Evaluations.Add(_mapperHelper.Map<EvaluationEntity, Evaluation>(evaluationEntity));
                else
                {
                    var dbEvaluation = dbStudent.Evaluations.FirstOrDefault(e => e.Id == evaluationEntity.Id);
                    if (dbEvaluation != null)
                    {
                        dbEvaluation.Grade = evaluationEntity.Grade;
                        dbEvaluation.AdditionalExplanation = evaluationEntity.AdditionalExplanation;
                    }
                }
            }
        }

        #endregion
    }
}
