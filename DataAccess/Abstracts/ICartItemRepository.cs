using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface ICartItemRepository : IAsyncRepository<CartItem>
{
}