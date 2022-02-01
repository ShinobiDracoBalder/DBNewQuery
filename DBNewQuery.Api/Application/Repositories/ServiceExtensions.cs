using DBNewQuery.Api.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DBNewQuery.Api.Application.Repositories
{
    public static class ServiceExtensions
    {
        public static void AddApplication(this IServiceCollection service)
        {
            service.AddTransient<IUnitOfWork, UnitOfWork>();
            service.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
