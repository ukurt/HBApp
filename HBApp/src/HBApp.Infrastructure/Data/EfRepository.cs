using HBApp.SharedKernel;
using HBApp.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HBApp.Infrastructure.Data
{

    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById<T>(int id) where T : BaseEntity
        {
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public Task<T> GetAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            return _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public Task<T> GetByIdAsync<T>(int id) where T : BaseEntity
        {
            return _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public Task<List<T>> ListAsync<T>() where T : BaseEntity
        {
            return _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync<T>(T entity) where T : BaseEntity
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T1> UpdateAsycn<T1>(T1 entity) where T1 : BaseEntity
        {
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).Property(p => p.Id).IsModified = true;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public IQueryable<T> GetAll<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            return _dbContext.Set<T>().Where(predicate);
        }
    }
}
