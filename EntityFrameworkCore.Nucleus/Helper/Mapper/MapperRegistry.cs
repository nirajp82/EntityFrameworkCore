using AutoMapper;
using EntityFrameworkCore.APIModel;
using EntityFrameworkCore.DataModel;

namespace EntityFrameworkCore.Nucleus
{
    internal class EntityModelMapperRegistry : Profile
    {
        #region Constructor
        public EntityModelMapperRegistry()
        {
            Map<StudentEntity, Student>();

            var mapExpr = Map<Student, StudentEntity>();
            mapExpr.ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => $"{src.LastName}, {src.FirstName}"));

            Map<StudentDetail, StudentDetailEntity>();
            Map<StudentSubject, StudentSubjectEntity>();
            Map<Evaluation, EvaluationEntity>();
            Map<Subject, SubjectEntity>();
        }
        #endregion


        #region Private Methods
        IMappingExpression<source, dest> Map<source, dest>() => CreateMap<source, dest>();
        #endregion
    }
}
