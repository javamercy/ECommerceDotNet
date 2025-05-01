using Business.Abstracts;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class CartItemManager : ICartItemService
{
    private readonly ICartItemRepository _cartItemRepository;

    public CartItemManager(ICartItemRepository cartItemRepository)
    {
        _cartItemRepository = cartItemRepository;
    }

    public async Task AddAsync(CartItem cartItem)
    {
        await _cartItemRepository.AddAsync(cartItem);
    }

    public async Task<CartItem> GetByIdAsync(int id)
    {
        var cartItem = await _cartItemRepository.GetAsync(c => c.Id == id);

        if (cartItem == null) throw new Exception("Cart Item not found");

        return cartItem;
    }
}