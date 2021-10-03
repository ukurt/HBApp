using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HBApp.SharedKernel.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync<T>(int id) where T : BaseEntity;
        Task<List<T>> ListAsync<T>() where T : BaseEntity;
        Task<T> AddAsync<T>(T entity) where T : BaseEntity;
        Task<T> GetAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;
    }
}