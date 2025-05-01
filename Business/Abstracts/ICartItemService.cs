using Entities.Concretes;

namespace Business.Abstracts;

public interface ICartItemService
{
    Task AddAsync(CartItem cartItem);

    Task<CartItem> GetByIdAsync(int id);
}