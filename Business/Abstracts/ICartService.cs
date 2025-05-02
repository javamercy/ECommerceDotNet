using Business.DTOs.Carts;
using Business.DTOs.Carts.AddItemToCart;
using Business.DTOs.Carts.DeleteCartItemFromCart;
using Business.DTOs.Carts.GetByCustomerId;
using Entities.Concretes;

namespace Business.Abstracts;

public interface ICartService
{
    Task AddAsync(Cart cart);
    Task UpdateAsync(Cart cart);

    Task<CartResponse> DeleteCartItemFromCartAsync(DeleteCartItemFromCartRequest request);
    Task<CartResponse> AddItemToCartAsync(AddItemToCartRequest request);
    Task<CartResponse> GetByCustomerIdAsync(GetByCustomerIdRequest request);
}
