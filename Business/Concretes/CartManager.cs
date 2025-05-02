using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Carts;
using Business.DTOs.Carts.AddItemToCart;
using Business.DTOs.Carts.DeleteCartItemFromCart;
using Business.DTOs.Carts.GetByCustomerId;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class CartManager : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;
    private readonly IProductRepository _productService;

    public CartManager(ICartRepository cartRepository, IProductRepository productService, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _productService = productService;
        _mapper = mapper;
    }

    public async Task AddAsync(Cart cart)
    {
        await _cartRepository.AddAsync(cart);
    }


    public Task UpdateAsync(Cart cart)
    {
        return _cartRepository.UpdateAsync(cart);
    }

    public async Task<CartResponse> GetByCustomerIdAsync(GetByCustomerIdRequest request)
    {
        var cart = await _cartRepository.GetAsync(
            c => c.CustomerId == request.CustomerId,
            c => c.Include(c => c.CartItems).ThenInclude(ci => ci.Product));

        if (cart == null)
            return new CartResponse
            {
                CustomerId = request.CustomerId,
                CartItems = []
            };

        return _mapper.Map<CartResponse>(cart);
    }

    public async Task<CartResponse> DeleteCartItemFromCartAsync(
        DeleteCartItemFromCartRequest request)
    {
        var cart = await _cartRepository.GetAsync(c => c.Id == request.CartId,
            c => c.Include(c => c.CartItems).ThenInclude(c => c.Product));

        if (cart == null) throw new Exception("Cart not found");

        var existingCartItem = cart.CartItems.FirstOrDefault(c => c.ProductId == request.ProductId);

        if (existingCartItem == null) throw new Exception("Cart item not found");

        cart.CartItems.Remove(existingCartItem);

        await _cartRepository.UpdateAsync(cart);

        return _mapper.Map<CartResponse>(cart);
    }

    public async Task<CartResponse> AddItemToCartAsync(AddItemToCartRequest request)
    {
        var product = await _productService.GetAsync(p => p.Id == request.ProductId);
        if (product == null) throw new Exception("Product not found");

        var cart = await _cartRepository.GetAsync(c => c.CustomerId == request.CustomerId,
            c => c.Include(c => c.CartItems).ThenInclude(c => c.Product));
        if (cart == null)
        {
            cart = new Cart
            {
                CustomerId = request.CustomerId,
                CartItems = []
            };
            await _cartRepository.AddAsync(cart);
        }

        var existingCartItem = cart.CartItems?.FirstOrDefault(ci => ci.ProductId == request.ProductId);
        if (existingCartItem != null)
        {
            existingCartItem.Quantity += request.Quantity;
            await _cartRepository.UpdateAsync(cart);
        }
        else
        {
            var cartItem = new CartItem
            {
                CartId = cart.Id,
                ProductId = request.ProductId,
                Quantity = request.Quantity
            };

            cart.CartItems ??= new List<CartItem>();
            cart.CartItems.Add(cartItem);
            await _cartRepository.UpdateAsync(cart);
        }

        return _mapper.Map<CartResponse>(cart);
    }
}
