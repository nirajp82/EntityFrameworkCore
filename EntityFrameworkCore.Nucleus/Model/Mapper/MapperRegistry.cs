using AutoMapper;
using EntityFrameworkCore.APIModel;
using EntityFrameworkCore.DataModel;

namespace EntityFrameworkCore.Nucleus
{
    internal class EntityModelMapperRegistry : Profile
    {
        #region Constructor
        internal EntityModelMapperRegistry()
        {
            Map<StudentEntity, Student>();
            Map<Student, StudentEntity>();
        }
        #endregion

        #region Private Methods
        IMappingExpression<source, dest> Map<source, dest>() => CreateMap<source, dest>();
        #endregion
    }
}
