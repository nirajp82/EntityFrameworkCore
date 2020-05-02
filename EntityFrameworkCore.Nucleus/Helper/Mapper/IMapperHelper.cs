using System.Collections.Generic;

namespace EntityFrameworkCore.Nucleus
{
    public interface IMapperHelper
    {
        dest Map<src, dest>(src entity);
        IEnumerable<dest> MapList<src, dest>(IEnumerable<src> list);
    }
}
