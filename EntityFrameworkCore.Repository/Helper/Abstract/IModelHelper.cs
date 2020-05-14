using EntityFrameworkCore.DataModel;
using System;
using System.Collections.Generic;

namespace EntityFrameworkCore.Repository
{
    public interface IModelHelper
    {
        ICollection<T> MergeList<T>(ICollection<T> sourceList, ICollection<T> dbList, 
            Action<T, T> delSrcDestMapper) where T : BaseModel;
    }
}