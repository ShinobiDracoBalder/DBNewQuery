using DBNewQuery.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewCrudDemo.DataBase.Repositories
{
    public class FactoryRepository<TEntity> : IFactoryRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<TEntity> _dbSet;

        public FactoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<TEntity>();
        }
        public void Add(TEntity data)
        {
            throw new NotImplementedException();
        }

        public Task<Response> CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Get()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity data)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> SaveAllAsync()
        {
            return await this._dataContext.SaveChangesAsync() > 0;
        }
    }
}
