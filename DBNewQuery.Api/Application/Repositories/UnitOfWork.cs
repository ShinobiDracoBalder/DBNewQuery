using DBNewQuery.Api.Application.Interfaces;

namespace DBNewQuery.Api.Application.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IProductRepository productRepository)
        {
            Products = productRepository;
        }

        public IProductRepository Products { get; }
    }
}
