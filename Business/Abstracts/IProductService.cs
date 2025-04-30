using Entities.Concretes;

namespace Business.Abstracts
{
    public interface IProductService
    {
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetListAsync();
    }
}