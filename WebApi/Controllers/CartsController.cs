using Business.Abstracts;
using Business.DTOs.Carts.AddItemToCart;
using Business.DTOs.Carts.DeleteCartItemFromCart;
using Business.DTOs.Carts.GetByCustomerId;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartsController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartsController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpPost("GetByCustomerId")]
    public async Task<IActionResult> GetByCustomerId([FromBody] GetByCustomerIdRequest request)
    {
        var response = await _cartService.GetByCustomerIdAsync(request);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Add(Cart cart)
    {
        await _cartService.AddAsync(cart);

        return Created("", cart);
    }

    [HttpPut]
    public async Task<IActionResult> Update(Cart cart)
    {
        await _cartService.UpdateAsync(cart);

        return NoContent();
    }

    [HttpPost("AddCartItemToCart")]
    public async Task<IActionResult> AddItemToCart(AddItemToCartRequest request)
    {
        var response = await _cartService.AddItemToCartAsync(request);

        return Ok(response);
    }

    [HttpPost("DeleteCartItemFromCart")]
    public async Task<IActionResult> DeleteCartItemFromCart([FromBody] DeleteCartItemFromCartRequest request)
    {
        var response = await _cartService.DeleteCartItemFromCartAsync(request);

        return Ok(response);
    }
}
