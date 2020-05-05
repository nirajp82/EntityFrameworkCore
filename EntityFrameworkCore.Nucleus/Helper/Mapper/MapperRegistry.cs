using AutoMapper;
using EntityFrameworkCore.APIModel;
using EntityFrameworkCore.DataModel;
using Microsoft.Data.SqlClient;

namespace EntityFrameworkCore.Nucleus
{
    internal class EntityModelMapperRegistry : Profile
    {
        #region Constructor
        public EntityModelMapperRegistry()
        {
            Map<string, string>().ConvertUsing(str => string.IsNullOrWhiteSpace(str) ? str : str.Trim());

            var mapExpr = Map<StudentEntity, Student>();
            mapExpr.ForMember(dest => dest.StudentAddress,
                opt =>
                {
                    opt.MapFrom(src => !string.IsNullOrWhiteSpace(src.Address)
                    ? new StudentAddress { Address = src.Address }
                    : null);
                });

            Map<Student, StudentEntity>();

            Map<StudentAddress, StudentAddressEntity>();
            Map<StudentAddressEntity, StudentAddress>();

            Map<StudentSubject, StudentSubjectEntity>();
            Map<StudentSubjectEntity, StudentSubject>();

            Map<Evaluation, EvaluationEntity>();
            Map<EvaluationEntity, Evaluation>();

            Map<Subject, SubjectEntity>();
            Map<SubjectEntity, Subject>();
        }
        #endregion


        #region Private Methods
        IMappingExpression<source, dest> Map<source, dest>() => CreateMap<source, dest>();
        #endregion
    }
}
