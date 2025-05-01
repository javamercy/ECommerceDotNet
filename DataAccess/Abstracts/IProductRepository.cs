using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IProductRepository : IAsyncRepository<Product>
{
}