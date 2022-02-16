using DBNewQuery.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewCrudDemo.DataBase.Repositories
{
    public class GeneroRepositoryFactory<T> : IGeneroRepositoryFactory<T> where T : class
    {
        private readonly DataContext _datacontext;

        public GeneroRepositoryFactory(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public Task<T> CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
