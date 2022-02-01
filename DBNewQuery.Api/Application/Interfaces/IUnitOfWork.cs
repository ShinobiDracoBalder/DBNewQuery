namespace DBNewQuery.Api.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
    }
}
