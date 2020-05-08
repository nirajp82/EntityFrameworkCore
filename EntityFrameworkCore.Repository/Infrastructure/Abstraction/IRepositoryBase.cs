﻿using EntityFrameworkCore.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Repository
{
    public interface IRepositoryBase<T> where T : BaseModel
    {
        Task AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task DeleteAsync(long id);

        IQueryable<T> FindAll(IEnumerable<string> includes = null);

        IQueryable<T> Find(Expression<Func<T, bool>> expression);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate, IEnumerable<string> includes,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? skip = null, int? take = null,
            bool isNoTracking = true);

        Task<T> FindFirstAsync(Expression<Func<T, bool>> expression, IEnumerable<string> includes = null);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);

        Task<long> CountAsync(Expression<Func<T, bool>> expression);
    }
}