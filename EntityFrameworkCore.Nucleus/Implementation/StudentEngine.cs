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
        public StudentEntity Add(StudentEntity entity)
        {
            Student student = _mapperHelper.Map<StudentEntity, Student>(entity);
            _unitOfWork.StudentRepository.Add(student);
            _unitOfWork.Save();
            return _mapperHelper.Map<Student, StudentEntity>(student);
        }

        public async Task DeleteAsync(long studentId)
        {
            await _unitOfWork.StudentRepository.DeleteAsync(studentId);
            _unitOfWork.Save();
        }

        public async Task<StudentEntity> FindAsync(long studentId)
        {
            Student student = await _unitOfWork.StudentRepository.FindFirstAsync(studentId);
            return _mapperHelper.Map<Student, StudentEntity>(student);
        }

        public IEnumerable<StudentEntity> FindAll()
        {
            IEnumerable<Student> students = _unitOfWork.StudentRepository.FindAll();
            return _mapperHelper.MapList<Student, StudentEntity>(students);
        }

        public async Task<StudentEntity> Update(StudentEntity entity)
        {
            Student dbStudent = await _unitOfWork.StudentRepository.FindFirstAsync(entity.Id);
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
            UpdateAddress(dbStudent, entity);
            UpdateSubject(dbStudent, entity);
            UpdateEnrollment(dbStudent, entity);
        }

        private void UpdateAddress(Student dbStudent, StudentEntity entity)
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

        private void UpdateSubject(Student dbStudent, StudentEntity entity)
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

            ManageSubjects(dbStudent, entity);
        }

        private void UpdateEnrollment(Student dbStudent, StudentEntity entity)
        {
            //Remove all Student Subjects
            if (entity.StudentEnrollments == null)
            {
                dbStudent.StudentEnrollments = null;
                return;
            }

            //Add All Student subjects
            if (dbStudent.StudentEnrollments == null)
            {
                dbStudent.StudentEnrollments = _mapperHelper.MapList<StudentEnrollmentEntity, StudentEnrollment>(entity.StudentEnrollments).ToList();
                return;
            }

            ManageEnrollment(dbStudent, entity);
        }

        private void ManageSubjects(Student dbStudent, StudentEntity entity)
        {
            IEnumerable<long> dbSubIdList = dbStudent.StudentSubjects.Select(ss => ss.Id).ToList();
            IEnumerable<long> entitySubIdList = entity.StudentSubjects.Select(ss => ss.Id);

            //Remove subjects.
            foreach (var dbSubId in dbSubIdList.Where(dss => !entitySubIdList.Contains(dss)))
                dbStudent.StudentSubjects.Remove(dbStudent.StudentSubjects.FirstOrDefault(ss => ss.Id == dbSubId));


            //Add/Update StudentEnrollments
            foreach (var studentSubjectEntity in entity.StudentSubjects)
            {
                if (studentSubjectEntity.Id == 0)
                    dbStudent.StudentSubjects.Add(_mapperHelper.Map<StudentSubjectEntity, StudentSubject>(studentSubjectEntity));
                else
                {
                    var dbStudentSubject = dbStudent.StudentSubjects.FirstOrDefault(e => e.Id == studentSubjectEntity.Id);
                    if (dbStudentSubject != null)
                    {
                        dbStudentSubject.SubjectId = studentSubjectEntity.SubjectId;
                    }
                }
            }
        }

        private void ManageEnrollment(Student dbStudent, StudentEntity entity)
        {
            IEnumerable<long> dbEnrollIdList = dbStudent.StudentEnrollments.Select(ss => ss.Id).ToList();
            IEnumerable<long> entityEnrollIdList = entity.StudentEnrollments.Select(ss => ss.Id);

            //Remove StudentEnrollments.
            foreach (var dbEvalId in dbEnrollIdList.Where(dss => !entityEnrollIdList.Contains(dss)))
                dbStudent.StudentEnrollments.Remove(dbStudent.StudentEnrollments.FirstOrDefault(ss => ss.Id == dbEvalId));

            //Add/Update StudentEnrollments
            foreach (var StudentEnrollmentEntity in entity.StudentEnrollments)
            {
                if (StudentEnrollmentEntity.Id == 0)
                    dbStudent.StudentEnrollments.Add(_mapperHelper.Map<StudentEnrollmentEntity, StudentEnrollment>(StudentEnrollmentEntity));
                else
                {
                    var dbStudentEnrollment = dbStudent.StudentEnrollments.FirstOrDefault(e => e.Id == StudentEnrollmentEntity.Id);
                    if (dbStudentEnrollment != null)
                    {
                        dbStudentEnrollment.Grade = StudentEnrollmentEntity.Grade;
                        dbStudentEnrollment.AdditionalExplanation = StudentEnrollmentEntity.AdditionalExplanation;
                    }
                }
            }
        }

        #endregion
    }
}
