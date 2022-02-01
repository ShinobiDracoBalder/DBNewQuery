using DBNewQuery.Api.Application.Interfaces;

namespace DBNewQuery.Api.Application.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IProductRepository productRepository, IEspecialidadRepository especialidadRepository)
        {
            Products = productRepository;
            Speciality = especialidadRepository;
        }

        public IProductRepository Products { get; }
        public IEspecialidadRepository Speciality { get; }
    }
}
