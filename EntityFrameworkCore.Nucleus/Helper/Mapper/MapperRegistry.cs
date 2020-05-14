using AutoMapper;
using EntityFrameworkCore.APIModel;
using EntityFrameworkCore.DataModel;

namespace EntityFrameworkCore.Nucleus
{
    internal class MapperRegistry : Profile
    {
        #region Constructor
        public MapperRegistry()
        {
            Map<string, string>().ConvertUsing(str => string.IsNullOrWhiteSpace(str) ? str : str.Trim());

            Map<StudentEntity, Student>().ForMember(dest => dest.StudentAddress,
                opt =>
                {
                    opt.MapFrom(src => !string.IsNullOrWhiteSpace(src.Address)
                    ? new StudentAddress { Address = src.Address }
                    : null);
                });

            Map<Student, StudentEntity>().ForMember(dest => dest.Address,
                opt =>
                {
                    opt.MapFrom(src => src.StudentAddress != null ? src.StudentAddress.Address : null);
                });

            Map<StudentSubject, StudentSubjectEntity>();
            Map<StudentSubjectEntity, StudentSubject>();

            Map<StudentEnrollment, StudentEnrollmentEntity>();
            Map<StudentEnrollmentEntity, StudentEnrollment>();

            Map<Subject, SubjectEntity>();
            Map<SubjectEntity, Subject>();
        }
        #endregion


        #region Private Methods
        IMappingExpression<source, dest> Map<source, dest>() => CreateMap<source, dest>();
        #endregion
    }
}
