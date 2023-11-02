﻿using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application.Interfaces.Common
{ 
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(int skip, int take);
        Task<IEnumerable<R>> GetAll<R>(Expression<Func<T, R>> selector);
         Task<IEnumerable<R>> GetAll<R>(Expression<Func<T, R>> selector, int skip, int take);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
        Task<IEnumerable<R>> Find<R>(Expression<Func<T, R>> selector, Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression, int skip, int take);
        Task<IEnumerable<R>> Find<R>(Expression<Func<T, R>> selector, Expression<Func<T, bool>> expression, int skip, int take);
        Task Add(T entity);
        Task<T> AddAndReturn(T entity);
        void Remove(T entitiy);
        void Update(T entitiy);
        Task<T?> GetById(int Id);
        Task<T?> GetByStringId(string Id);
        public List<T> Addlist(List<T> entity);
    }

}
