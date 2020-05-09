﻿using EntityFrameworkCore.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Repository
{
    internal abstract class RepositoryBase<T> : IRepositoryBase<T> where T : BaseModel
    {
        #region Member
        protected ApplicationContext _context { get; }
        #endregion


        #region Constuctor
        protected RepositoryBase(ApplicationContext context)
        {
            _context = context;
        }
        #endregion


        #region Public Methods
        public void Add(T entity)
        {
             _context.Set<T>().Add(entity);
        }


        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry<T>(entity).State = EntityState.Modified;
            //_context.Set<T>().Update(entity);
        }


        public void Delete(T entity)
        {
            if (entity != null)
                _context.Set<T>().Remove(entity);
        }

        public async Task DeleteAsync(long id)
        {
            T model = await FindFirstAsync(e => e.Id == id);
            Delete(model);
        }


        public IQueryable<T> FindAll(IEnumerable<string> includes = null)
        {
            return Find(null, includes);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return Find(expression, null);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression, IEnumerable<string> includes, Func<IQueryable<T>,
                IOrderedQueryable<T>> orderBy = null, int? skip = null, int? take = null, bool isNoTracking = true)
        {
            IQueryable<T> queryable = _context.Set<T>();

            if (expression != null)
                queryable = queryable.Where(expression);

            if (includes?.Any() == true)
                queryable = includes.Aggregate(queryable, (current, inc) => current.Include(inc));

            if (orderBy != null)
                queryable = orderBy(queryable);

            if (skip.GetValueOrDefault() > 0)
                queryable = queryable.Skip(skip.Value);

            if (take.GetValueOrDefault() > 0)
                queryable = queryable.Take(take.Value);

            if (isNoTracking)
                queryable = queryable.AsNoTracking();

            return queryable;
        }

        public async Task<T> FindFirstAsync(Expression<Func<T, bool>> expression, IEnumerable<string> includes = null)
        {
            return await Find(expression, includes).FirstOrDefaultAsync();
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
        {
            return await Find(expression, null).AnyAsync();
        }

        public async Task<long> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await Find(expression, null).LongCountAsync();
        }
        #endregion
    }
}