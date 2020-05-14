using EntityFrameworkCore.DataModel;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCore.Repository
{
    public class ModelHelper : IModelHelper
    {
        public ICollection<T> MergeList<T>(ICollection<T> sourceList, ICollection<T> dbList, 
            Action<T, T> delSrcDestMapper)
            where T : BaseModel
        {
            //Source is null so remove all the object from the database. 
            if (sourceList?.Any() == false)
                return null;

            //There are no records in the database, Add all data from source list.
            if (dbList?.Any() == false)
                return sourceList;

            //Merge(Add/Update/Delete) Enrollments
            IEnumerable<long> dbIdList = dbList.Select(de => de.Id).ToList();
            IEnumerable<long> entityIdList = sourceList.Select(se => se.Id);

            //Remove StudentEnrollments.
            foreach (var dbEvalId in dbIdList.Where(dss => !entityIdList.Contains(dss)))
                dbList.Remove(dbList.FirstOrDefault(ss => ss.Id == dbEvalId));

            //Add/Update StudentEnrollments
            foreach (var entity in sourceList)
            {
                if (entity.Id == 0)
                    dbList.Add(entity);
                else
                {
                    var dbEntity = dbList.FirstOrDefault(e => e.Id == entity.Id);
                    delSrcDestMapper(entity, dbEntity);
                }
            }

            return dbList;
        }
    }
}