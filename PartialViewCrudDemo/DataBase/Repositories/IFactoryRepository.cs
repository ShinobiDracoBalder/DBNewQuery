using DBNewQuery.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewCrudDemo.DataBase.Repositories
{
    public interface IFactoryRepository<TEntity>
    {
        IEnumerable<TEntity> Get();
        Task<TEntity> GetAsync(int id);
        void Add(TEntity data);
        void Delete(int id);
        void Update(TEntity data);
        Task<Response> CreateAsync(TEntity entity);
        Task<Response> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Save();
        Task<bool> SaveAllAsync();
    }
}
