using System.Linq;
using System.Threading.Tasks;

namespace PartialViewCrudDemo.DataBase.Repositories
{
    public  interface IGeneroRepositoryFactory<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
