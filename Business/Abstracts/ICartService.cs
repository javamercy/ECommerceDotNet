using Business.DTOs.Carts.AddItemToCart;
using Business.DTOs.Carts.DeleteCartItemFromCart;
using Business.DTOs.Carts.GetByCustomerId;
using Entities.Concretes;

namespace Business.Abstracts;

public interface ICartService
{
    Task AddAsync(Cart cart);
    Task UpdateAsync(Cart cart);

    Task<DeletedCartItemFromCartResponse> DeleteCartItemFromCartAsync(DeleteCartItemFromCartRequest request);
    Task<AddItemToCartResponse> AddItemToCartAsync(AddItemToCartRequest request);
    Task<GetByCustomerIdResponse> GetByCustomerIdAsync(GetByCustomerIdRequest request);
}